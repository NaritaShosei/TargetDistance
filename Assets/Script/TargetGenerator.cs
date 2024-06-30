using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGeneretar : MonoBehaviour
{
    [SerializeField] GameObject _targetPrefab;
    Vector2 _targetPos;
    bool _create = true;
    [SerializeField] float _maxPosX = 2.7f;
    [SerializeField] float _maxPosY = 29.83f;
    [SerializeField] float _minPosY = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_create)
        {
            _targetPos.x = Random.Range(-_maxPosX, _maxPosX);
            _targetPos.y = Random.Range(_minPosY, _maxPosY);
            Instantiate(_targetPrefab,_targetPos,Quaternion.identity);
            _create = false;
        }
    }
}
