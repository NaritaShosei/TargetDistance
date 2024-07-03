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
        ingame, result, end
    }

    // Start is called before the first frame update
    void Start()
    {
        _text = GameObject.Find("DistanceText").GetComponent<Text>();
        switch (_gameMode)
        {
            case GameMode.result:
                Result();
                break;
            case GameMode.end:
                End();
                break;
            case GameMode.ingame:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameMode == GameMode.ingame)
        {
            InGame();
        }
    }
    void InGame()
    {
        _playerObject = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _targetObject = GameObject.FindGameObjectWithTag("Target").GetComponent<Transform>();
        _dis = Vector2.Distance(_playerObject.transform.position, _targetObject.transform.position);
        _distance = _dis;
        _text.text = $"TARGETまでの距離\n残り{_distance.ToString("F1")}m";
    }
    void Result()
    {
        if (HippariMove._stageCount != 0)
        {
            if (_distance <= 0.65f && _distance >= 0)
            {
                _score = 500;
            }
            else if (_distance <= 2.519f)
            {
                _score = 100;
            }
            else
            {
                _score = 0;
            }
        }
        _staticScore += _score;
        _text.text = $"スコア\n{_score}点";

    }
    void End()
    {
        HippariMove._stageCount = 0;
        _text.text = $"トータルスコア\n{_staticScore}点";
    }
}
