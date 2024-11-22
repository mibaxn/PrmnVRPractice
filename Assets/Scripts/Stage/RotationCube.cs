using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCube : MonoBehaviour
{
    private float _spd;
    [SerializeField] private float _min;
    [SerializeField] private float _max;

    void Start()
    {
        _spd = Random.Range(_min, _max);
        transform.position = new Vector3(0, transform.position.y, 0);
    }

    void Update()
    {
        transform.Rotate(0, _spd, 0);
    }
}
