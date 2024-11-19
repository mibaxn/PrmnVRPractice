using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    private Rigidbody _rb;

    private void Start()
    {
        _rb = Singleton.Player.GetComponent<Rigidbody>();
        _rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    public void StartGame()
    {
        _rb.constraints = RigidbodyConstraints.None;
        gameObject.SetActive(false);
    }
}
