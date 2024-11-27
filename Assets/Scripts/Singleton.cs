using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    [Header("プレイヤーのゲームオブジェクト"), SerializeField]
    private GameObject _player;

    [Header("プレイヤーの最大HP.衝突時にy軸速さの分だけ減少する"), SerializeField]
    private float _maxHp;

    public static GameObject Player { get; private set; }
    public static float MaxHp { get; private set; }

    private void Awake()
    {
        Player = _player;
        MaxHp = _maxHp;
    }
}