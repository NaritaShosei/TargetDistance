using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGenerator : MonoBehaviour
{
    [SerializeField] GameObject _targetPrefab;
    [SerializeField] GameObject _jamamonoObject;
    Vector2 _targetPos;
    Vector2 _jamamonoPos;
    Vector2 _jamamonoPos2;
    [SerializeField] float _maxPosX = 2.7f;
    [SerializeField] float _maxPosY = 29.83f;
    [SerializeField] float _minPosY = 10;
    // Start is called before the first frame update
    void Start()
    {
        _targetPos.x = Random.Range(-_maxPosX, _maxPosX);
        _targetPos.y = Random.Range(_minPosY, _maxPosY);
        _jamamonoPos.x = Random.Range(-_maxPosX / 2, _maxPosX / 2) / 2;
        _jamamonoPos.y = Random.Range(_minPosY / 2, _maxPosY / 2) / 2;
        _jamamonoPos2.x = Random.Range(-2, 2);
        Instantiate(_targetPrefab, _targetPos, Quaternion.identity);
        if (HippariMove._count > 4)
        {
            Instantiate(_jamamonoObject, _targetPos - _jamamonoPos, Quaternion.identity);
            if (HippariMove._count >= 9)
            {
                Instantiate(_jamamonoObject, _targetPos - _jamamonoPos - _jamamonoPos / 2 + _jamamonoPos2, Quaternion.identity);
                Debug.LogWarning("9");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
