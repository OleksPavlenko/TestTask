using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointManager : MonoBehaviour
{
    [SerializeField]
    private PlayerManager _playerManager;
    [SerializeField]
    private MousePositionChecker _mousePositionChecker;
    private Boolean _pointIsDestroyed;
    private GameObject _pointPrefab;
    private GameObject _point;
    private Vector3 _distanceToMousePosition;
    private Queue<Vector3> _pointsPosition;
    private Queue<GameObject> _points;

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
        _pointsPosition = new Queue<Vector3>();
        _points = new Queue<GameObject>();
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
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float enterDistantion = 0.0f;
           
            if (_mousePositionChecker.Plane.Raycast(ray, out enterDistantion))
            {
                if (!_mousePositionChecker.CheckIfRaycastHasCollisionWithUI())
                {
                    _distanceToMousePosition = ray.GetPoint(enterDistantion);
                    _pointsPosition.Enqueue(_distanceToMousePosition);
                    _point = Instantiate(_pointPrefab, _distanceToMousePosition, Quaternion.identity);
                    _points.Enqueue(_point);
                }
            }
        }

        if (_pointsPosition.Count > 0 && _playerManager.PlayerTransform.position == _pointsPosition.Peek())
        {
            Destroy(_points.Peek());
            _points.Dequeue();
            _pointsPosition.Dequeue();
        }
    }
}
