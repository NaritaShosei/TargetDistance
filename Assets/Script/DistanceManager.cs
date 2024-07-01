using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DistanceManager : MonoBehaviour
{
    float _dis;
    static float _distance;
    Transform _playerObject;
    Transform _targetObject;
    Text _text;
    [SerializeField] GameMode _gameMode;
    int _score;
    static int _staticScore;
    enum GameMode
    {
        ingame, result
    }

    // Start is called before the first frame update
    void Start()
    {
        _text = GameObject.Find("DistanceText").GetComponent<Text>();
        if (_gameMode == GameMode.result)
        {
            Result();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameMode == GameMode.ingame)
        { 
                Invoke("InGame", 0.001f);//一瞬nullが出るから少し遅らせて呼び出す
        }
    }
    void InGame()
    {
        _playerObject = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _targetObject = GameObject.FindGameObjectWithTag("Target").GetComponent<Transform>();
        _dis = Vector2.Distance(_playerObject.transform.position, _targetObject.transform.position);
        _distance = _dis;
        _text.text = $"ターゲットまでの距離\n残り{_distance.ToString("F1")}m";
    }
    void Result()
    {
        if (_distance <= 0.247f && _distance >= 0)
        {
            _score += 500;
        }
        else if (_distance <= 2.519f)
        {
            _score += 100;
        }
        else
        {
            _score += 0;
        }
        _staticScore += _score;
        _text.text = $"スコア\n{_staticScore}";
    }
}
