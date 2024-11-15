using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoroller : MonoBehaviour
{
    private Rigidbody _player;
    [SerializeField] private int _magForce = 20;
    [SerializeField] private int _limitXzSpd = 10;
    [SerializeField] private int _limitYSpd = 60;

    void Start()
    {
        _player = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var force = Vector3.zero;
        if (Input.GetKey(KeyCode.D))
        {
            force += new Vector3(_magForce, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            force -= new Vector3(_magForce, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            force += new Vector3(0, 0, _magForce);
        }
        if (Input.GetKey(KeyCode.S))
        {
            force -= new Vector3(0, 0, _magForce);
        }
        _player.AddForce(force);
        _player.velocity = ClampSpd(_player.velocity, _limitXzSpd, _limitYSpd);
        //Debug.Log(new Vector2(_player.velocity.x, _player.velocity.z).magnitude);
        Debug.Log(_player.velocity.y);
    }

    /// <summary>
    /// プレイヤーのxz平面の速度がxzlimitを超えていたら、その大きさがlimitになるように修正する
    /// プレイヤーのy軸速度がylimitを超えていたら、ylimitに修正する
    /// </summary>
    Vector3 ClampSpd(Vector3 velocity, float xzlimit, float ylimit)
    {
        Vector2 xz = new Vector2(velocity.x, velocity.z);
        if (xz.magnitude > xzlimit)
        {
            xz = xz / xz.magnitude * xzlimit;
        }
        var yspd = Mathf.Abs(velocity.y) > ylimit ? MathF.Sign(velocity.y) * ylimit : velocity.y;
        return new Vector3(xz.x, yspd, xz.y);
    }
}
