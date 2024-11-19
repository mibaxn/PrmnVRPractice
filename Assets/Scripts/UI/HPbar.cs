using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    private Slider _slider;
    private PlayerContoroller _pc;

    void Start()
    {
        _slider = GetComponent<Slider>();
        _pc = Singleton.Player.GetComponent<PlayerContoroller>();

        _slider.minValue = 0;
        _slider.maxValue = _pc.Hp;
        _slider.value = _slider.maxValue;
    }

    private void Update()
    {
        _slider.value = _pc.Hp;
    }
}
