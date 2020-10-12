using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MousePositionChecker : MonoBehaviour
{
    public PlayerManager playerManager;
    public Queue<Vector3> mousePositionQueue = new Queue<Vector3>();

    private Vector3 _distanceToMousePosition;

    public Vector3 DistanceMousePosition
    {
        get { return _distanceToMousePosition; }
    }
   
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Plane Plane = new Plane(Vector3.up, playerManager.PlayerTransform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float dis = 0.0f;

            if (Plane.Raycast(ray, out dis))
            {
                if (!IsBuuton())
                {
                    _distanceToMousePosition = ray.GetPoint(dis);
                    mousePositionQueue.Enqueue(_distanceToMousePosition);
                }

            }

        }
    }

    public bool IsBuuton()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResults);
        return raycastResults.Count > 0;
    }
}
