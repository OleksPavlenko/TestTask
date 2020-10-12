using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerManager : MonoBehaviour
{
    private Transform _playerTransform;
    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private MousePositionChecker _mousePositionChecker;

    public MousePositionChecker MousePositionChecker
    {
        get { return _mousePositionChecker; }
    }

    public Transform PlayerTransform
    {
        get { return _playerTransform; }
    }

    void Start()
    {
        _playerTransform = this.transform;
    }

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (_mousePositionChecker.MousePositionQueue.Count > 0)
        {
            bool isPlayerPositionEqualMousePosition = _playerTransform.position == _mousePositionChecker.DistanceMousePosition;
            bool isPlayerPositionEqualMouseQueueFirstElement = _playerTransform.position == _mousePositionChecker.MousePositionQueue.Peek();

            if (!isPlayerPositionEqualMousePosition)
            {
                _playerTransform.position = Vector3.MoveTowards(_playerTransform.position, _mousePositionChecker.MousePositionQueue.Peek(), _moveSpeed * Time.deltaTime);
            }

            if (isPlayerPositionEqualMouseQueueFirstElement)
            {
                _mousePositionChecker.MousePositionQueue.Dequeue();
            }
        }
    }
}

