using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointManager : MonoBehaviour
{
    public PlayerManager playerManager;
    public MousePositionChecker mousePositionChecker;
    public Queue<Vector3> pointsPosition = new Queue<Vector3>();
    public Queue<GameObject> points = new Queue<GameObject>();

    private bool _pointIsDestroyed;
    private GameObject _pointPrefab;
    private GameObject _point;
    private Vector3 _distanceToMousePosition;

    public bool PointIsDestroyed
    {
        get { return _pointIsDestroyed; }
    }

    public GameObject Point
    {
        get { return _point; }
    }

    void Start()
    {
        _pointPrefab = Resources.Load<GameObject>("Point");
        _pointIsDestroyed = true;
    }

    void Update()
    {
        SpawnPoint();
    }

    private void SpawnPoint()
    {
        _pointIsDestroyed = false;

        if (Input.GetMouseButtonDown(0))
        {
            Plane Plane = new Plane(Vector3.up, playerManager.PlayerTransform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float dis = 0.0f;
           
            if (Plane.Raycast(ray, out dis))
            {
                if (!mousePositionChecker.IsBuuton())
                {
                    _distanceToMousePosition = ray.GetPoint(dis);
                    pointsPosition.Enqueue(_distanceToMousePosition);
                    _point = Instantiate(_pointPrefab, _distanceToMousePosition, Quaternion.identity);
                    points.Enqueue(_point);
                }
            }
        }

        if (pointsPosition.Count > 0 && playerManager.PlayerTransform.position == pointsPosition.Peek())
        {
            Destroy(points.Peek());
            points.Dequeue();
            pointsPosition.Dequeue();
        }
    }
}
