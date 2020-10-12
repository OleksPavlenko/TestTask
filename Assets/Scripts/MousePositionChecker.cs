using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MousePositionChecker : MonoBehaviour
{
    [SerializeField]
    private PlayerManager _playerManager;
    private Queue<Vector3> _mousePositionQueue;
    private Vector3 _distanceToMousePosition;
    private Plane _plane;

    public Queue<Vector3> MousePositionQueue
    {
        get { return _mousePositionQueue; }
    }

    public Vector3 DistanceMousePosition
    {
        get { return _distanceToMousePosition; }
    }

    public Plane Plane
    {
        get { return _plane; }
    }

    private void Start()
    {
        _mousePositionQueue = new Queue<Vector3>();
        _plane = new Plane(Vector3.up, _playerManager.PlayerTransform.position);
    }

    void Update()
    {
        MousePositionFinder();
    }

    private void MousePositionFinder()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float enterDistantion = 0.0f;

            if (_plane.Raycast(ray, out enterDistantion))
            {
                if (!CheckIfRaycastHasCollisionWithUI())
                {
                    _distanceToMousePosition = ray.GetPoint(enterDistantion);
                    _mousePositionQueue.Enqueue(_distanceToMousePosition);
                }

            }
        }
    }

    public bool CheckIfRaycastHasCollisionWithUI()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResults);
        return raycastResults.Count > 0;
    }
}
