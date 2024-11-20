using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCube : MonoBehaviour
{
    private float _spd;

    void Start()
    {
        _spd = Random.Range(1, 10);
        transform.position = new Vector3(0, transform.position.y, 0);
    }

    void Update()
    {
        transform.Rotate(0, _spd, 0);
    }
}
