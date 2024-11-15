using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class CameraMoving : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Vector3 _space;

    void Update()
    {
        gameObject.transform.position = _player.transform.position + _space;
    }
}
