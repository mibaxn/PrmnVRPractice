using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoroller : MonoBehaviour
{
    private Rigidbody _player;

    [Header("プレイヤーのHP.衝突時にy軸速さの分だけ減少する"), SerializeField]
    private float _hp;
    public float Hp { get => _hp; }

    [Header("移動の時に加える力の大きさ"), SerializeField]
    private float _magForce;

    [Header("xz平面の速さの上限"), SerializeField]
    private float _limitXzSpd;

    [Header("y軸速さの初期上限"), SerializeField]
    private float _limitYSpd;

    [Header("y軸速さの上限の最終的な増加量"), SerializeField]
    private float _addYSpd;

    [Header("ステージの長さ"), SerializeField]
    private int _stageLength;


    void Start()
    {
        _player = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (_hp <= 0) { Die(); }

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
        var ylimit = _limitYSpd + (_stageLength - transform.position.y) / _stageLength * _addYSpd;
        _player.velocity = ClampSpd(_player.velocity, _limitXzSpd, ylimit);
        Debug.Log($"{_player.velocity}, {ylimit}");
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
            xz = xz.normalized * xzlimit;
        }
        var yspd = Mathf.Abs(velocity.y) > ylimit ? MathF.Sign(velocity.y) * ylimit : velocity.y;
        return new Vector3(xz.x, yspd, xz.y);
    }


    private void Die()
    {
        gameObject.SetActive(false);
    }


    private void OnCollisionEnter(Collision collision)
    {
        _hp -= collision.relativeVelocity.y;
    }
}
