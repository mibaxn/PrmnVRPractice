using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    [Header("プレイヤーのゲームオブジェクト"), SerializeField]
    private GameObject _player;

    public static GameObject Player { get; private set; }

    private void Awake()
    {
        Player = _player;
    }
}