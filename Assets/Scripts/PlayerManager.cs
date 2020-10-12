using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerManager : MonoBehaviour
{
    private Transform _playerTransform;
    [SerializeField]
    private float _moveSpeed;

    public MousePositionChecker mousePositionChecker;

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
        if (mousePositionChecker.mousePositionQueue.Count > 0 && _playerTransform.position != mousePositionChecker.DistanceMousePosition)
        {
            _playerTransform.position = Vector3.MoveTowards(_playerTransform.position, mousePositionChecker.mousePositionQueue.Peek(), _moveSpeed * Time.deltaTime);
        }
       
        if (mousePositionChecker.mousePositionQueue.Count > 0 && _playerTransform.position == mousePositionChecker.mousePositionQueue.Peek())
        {
            mousePositionChecker.mousePositionQueue.Dequeue();
        }
    }
}

