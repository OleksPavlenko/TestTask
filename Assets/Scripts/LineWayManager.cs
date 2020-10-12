using System.Collections;
using System.Collections.Generic;
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
        _lineRenderer.SetPosition(0, new Vector3(_playerManager.PlayerTransform.position.x, 0, _playerManager.PlayerTransform.position.z));

        if (!_pointManager.PointIsDestroyed && _playerManager.MousePositionChecker.MousePositionQueue.Count > 0)
        {
            _lineRenderer.SetPosition(1, new Vector3(_mousePositionChecker.MousePositionQueue.Peek().x, 0, _mousePositionChecker.MousePositionQueue.Peek().z));
        }
        else
        {
            _lineRenderer.SetPosition(1, new Vector3(_playerManager.PlayerTransform.position.x, 0, _playerManager.PlayerTransform.position.z));
        }
    }
}
