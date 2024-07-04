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
    [SerializeField] float _spawnPosX = 2.7f;
    [SerializeField] float _maxPosY = 29.83f;
    [SerializeField] float _minPosY = 10;
    [SerializeField] int _checkPoint;
    [SerializeField] int _checkPoint2;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Spawn()
    {
        _targetPos.x = Random.Range(-_spawnPosX, _spawnPosX);
        _targetPos.y = Random.Range(_minPosY, _maxPosY);
        _jamamonoPos.x = Random.Range(-_spawnPosX / 2, _spawnPosX / 2);
        _jamamonoPos.y = _targetPos.y - Random.Range(2, 4);
        _jamamonoPos2.x = Random.Range(-_spawnPosX, _spawnPosX);
        _jamamonoPos2.y = _targetPos.y - Random.Range(4, 5);
        Instantiate(_targetPrefab, _targetPos, Quaternion.identity);
        if (HippariMove._stageCount > _checkPoint)
        {
            Instantiate(_jamamonoObject, _jamamonoPos, Quaternion.identity);
            if (HippariMove._stageCount >= _checkPoint2)
            {
                Instantiate(_jamamonoObject, _jamamonoPos2, Quaternion.identity);
                Debug.LogWarning(HippariMove._stageCount);
            }
        }
    }
}
