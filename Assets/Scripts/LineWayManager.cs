using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class LineWayManager : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    [SerializeField]
    private PlayerManager _playerManager;
    [SerializeField]
    private PointManager _pointManager;
    [SerializeField]
    private MousePositionChecker _mousePositionChecker;

    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        CreateWayToLineRenderer();
    }

    private void CreateWayToLineRenderer()
    {
        Vector3 lineRendererFirstPosition = new Vector3(_playerManager.PlayerTransform.position.x, 0, _playerManager.PlayerTransform.position.z);
        Vector3[] mousePositionArray = _mousePositionChecker.MousePositionQueue.ToArray();
        _lineRenderer.SetPosition(0, lineRendererFirstPosition);

        if (!_pointManager.PointIsDestroyed && mousePositionArray.Length > 0)
        {           
            for (int mousePositionIndex = 0; mousePositionIndex < mousePositionArray.Length; mousePositionIndex++)
            {
                int lineRendererPositionIndex = mousePositionIndex + 1;
                _lineRenderer.positionCount = mousePositionArray.Length + 1;
                _lineRenderer.SetPosition(lineRendererPositionIndex, new Vector3(mousePositionArray[mousePositionIndex].x, 0, mousePositionArray[mousePositionIndex].z));
            }
        }
        else
        {
            _lineRenderer.SetPosition(1, lineRendererFirstPosition);
        }
    }
}
