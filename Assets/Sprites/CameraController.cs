using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _target;
    float distance = -10;
    float lift = 1.5f;

    public void Move()
    {
        _camera.position = new Vector3(0, 1.5f, distance) + _target.position;
        _camera.LookAt(_target);
    }
}
