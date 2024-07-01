using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRoa : MonoBehaviour
{
    Transform _player;
    Transform _target;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("GetRoa", 0.001f);
    }

    // Update is called once per frame
    void Update()
    {
       // GetRoa();
    }
    void GetRoa()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _target = GameObject.FindGameObjectWithTag("Target").GetComponent<Transform>();
        var roa = Quaternion.LookRotation(Vector3.forward, _target.position - _player.position);
        transform.rotation = roa;
    }
}
