using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    [SerializeField] string _sceneName;
    [SerializeField] float _invokeTime;
    [SerializeField] AudioSource _audio;
    bool _push = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void SceneChange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void GetScene()
    {
        if (_push)
        {
            _audio?.Play();
            Invoke("InvokeGet", _invokeTime);
            _push = false;
        }
    }
    void InvokeGet()
    {
        SceneChange(_sceneName);
    }
}
