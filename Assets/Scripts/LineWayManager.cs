using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineWayManager : MonoBehaviour
{
    public LineRenderer lineRenderer;

    public PlayerManager playerManager;
    public PointManager pointManager;
    public MousePositionChecker mousePositionChecker;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        lineRenderer.SetPosition(0, new Vector3(playerManager.PlayerTransform.position.x, 0, playerManager.PlayerTransform.position.z));

        if (pointManager.PointIsDestroyed == false && playerManager.mousePositionChecker.mousePositionQueue.Count > 0)
        {
            lineRenderer.SetPosition(1, new Vector3(mousePositionChecker.mousePositionQueue.Peek().x, 0, mousePositionChecker.mousePositionQueue.Peek().z));
        }
        else
        {
            lineRenderer.SetPosition(1, new Vector3(playerManager.PlayerTransform.position.x, 0, playerManager.PlayerTransform.position.z));
        }
    }
}
