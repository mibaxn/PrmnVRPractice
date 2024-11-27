using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private PlayerContoroller _pc;
    private TextMeshProUGUI _text;
    private float _time;

    void Awake()
    {
        _pc = Singleton.Player.GetComponent<PlayerContoroller>();
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void ShowScore()
    {
        _time = Time.time - _time;
        string rank = (_time, _pc.Hp) switch
        {
            (_, 0) => "D",
            (< 35, _) => "A",
            (< 45, _) => "B",
            (< 55,  _) => "C",
            _ => "D",
        };

        var score = @$"時間: {_time :F1}秒
HP: {_pc.Hp / Singleton.MaxHp * 100 :F2}%
評価: {rank}
";

        _text.text = score;
    }

    public void StartStopWatch()
    {
        _time = Time.time;
    }
}
