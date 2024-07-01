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
    bool _countStart = true;
    int _zeroCount = 0;
    public static int _count = 0;
    [SerializeField] string _sceneName;
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
            }
        }
        if (_rb.IsSleeping() && !_stop)
        {
            if (_countStart)
            {
                _zeroCount = _count;
                _zeroCount += 1;
                _count = _zeroCount;
                _countStart = false;
                if (!_countStart)
                {
                    SceneChangeManager.SceneChange(_sceneName);
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(_count);
        }
    }

}
