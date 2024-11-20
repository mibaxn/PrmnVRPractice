using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _spd;
    private Rigidbody _rb;
    private static float _range = 40;
    private bool _collisionFlag = false;
    private bool _foundFlag = false;
    private float _delaySeconds = 10;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _spd = Random.Range(10, 15);
    }

    void Update()
    {
        if (_collisionFlag) { return; }
        var vec = Singleton.Player.transform.position - transform.position;
        if (!_foundFlag && vec.magnitude <= _range)
        {
            _foundFlag = true;
            var pspd = Mathf.Abs(Singleton.Player.GetComponent<Rigidbody>().velocity.y);
            _spd = Random.Range(pspd / 5, pspd / 2);
        }
        else if(_foundFlag && vec.magnitude > _range)
        {
            _collisionFlag = true;
            _rb.constraints = RigidbodyConstraints.FreezeAll;
            StartCoroutine(DelayDestroy(_delaySeconds));
        }

        if (_foundFlag)
        {
            _rb.velocity = vec.normalized * _spd;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == Singleton.Player)
        {
            _collisionFlag = true;
            _rb.useGravity = true;
            StartCoroutine(DelayDestroy(_delaySeconds));
        }
    }

    private IEnumerator DelayDestroy(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
