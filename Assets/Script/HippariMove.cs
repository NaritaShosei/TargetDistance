using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HippariMove : MonoBehaviour
{
    Rigidbody2D _rb;
    LineRenderer _lr;
    [SerializeField] float _power = 2.0f;
    [SerializeField] float _maxPower = 5.0f;
    Vector2 _startPos;
    Vector2 _endPos;
    bool _stop = true;
    bool _start = true;
    int _zeroCount = 0;
    public static int _stageCount = 0;
    [SerializeField] string _sceneName;
    [SerializeField] string _sceneNameEnd;
    [SerializeField] int _gameEndCount;
    [SerializeField] AudioSource _audio;
    [SerializeField] GameObject _SeObject;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _lr = GetComponent<LineRenderer>();
    }
    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (_stop)
            {
                _lr.enabled = true;
                _startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _lr.SetPosition(0, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 10)));
                _audio.Play();
            }
        }
        if (Input.GetMouseButton(0))
        {
            _lr.SetPosition(1, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 10)));
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (_stop)
            {
                _lr.enabled = false;
                _endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 force = Vector2.ClampMagnitude((_startPos - _endPos), _maxPower);
                _rb.AddForce(force * _power, ForceMode2D.Impulse);
                _stop = false;
                _audio.Stop();
                Instantiate(_SeObject);
            }
        }
        if (_rb.velocity.magnitude <= 0.03 && !_stop)//止まっている判定はmagnitudeでやったほうがいいらしい
        {
            if (_start)
            {
                _zeroCount += 1;
                _stageCount += _zeroCount;
                _start = false;
                if (!_start && _stageCount <= _gameEndCount)
                {
                    SceneChangeManager.SceneChange(_sceneName);
                }
                if (!_start && _stageCount > _gameEndCount)
                {
                    SceneChangeManager.SceneChange(_sceneNameEnd);
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(_stageCount);
        }
    }

}
