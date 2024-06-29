using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DistanceManager : MonoBehaviour
{
    float _dis;
    static float _distance;
    [SerializeField] GameObject _playerObject;
    [SerializeField] GameObject _targetObject;
    Text _text;
    [SerializeField] GameMode _gameMode;
    enum GameMode
    {
        ingame, result
    }

    // Start is called before the first frame update
    void Start()
    {
        _text = GameObject.Find("DistanceText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (_gameMode)
        {
            case GameMode.ingame:
                InGame();
                break;
            case GameMode.result:
                Result();
                break;

        }
    }
    void InGame()
    {
        _dis = Vector2.Distance(_playerObject.transform.position, _targetObject.transform.position);
        _distance  = _dis;
        _text.text = $"ターゲットまでの距離\n残り{_distance.ToString("F0")}m";
    }
    void Result()
    {
        
    }
}
