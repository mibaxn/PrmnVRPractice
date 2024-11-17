using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageContoroller : MonoBehaviour
{
    [Header("障害物となるオブジェクト")]
    [SerializeField] private GameObject[] _obstacles;

    [SerializeField] private GameObject _player;

    /// <summary>
    /// 障害物生成の基準となる位置
    /// x,z座標の情報を用いる.y座標はプレイヤー座標を基準とする.
    /// </summary>
    private Vector3 _center;

    void Start()
    {
        _center = new Vector3(transform.position.x, 0, transform.position.z);
    }

    void Update()
    {
        
    }
}
