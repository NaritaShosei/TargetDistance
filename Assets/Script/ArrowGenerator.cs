using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    Transform _player;
    [SerializeField] GameObject _arrowPrefab;
    Vector3 _position = new Vector3(0, 1, 0);
    // Start is called before the first frame update
    void Start()
    {
        Invoke("GetArrow", 0.001f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void GetArrow()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Instantiate(_arrowPrefab, _player.position + _position, Quaternion.identity);
    }
}
