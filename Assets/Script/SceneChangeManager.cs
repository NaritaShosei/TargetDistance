using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    [SerializeField] string _sceneName;
    [SerializeField] float _invokeTime;
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
        Invoke("InvokeGet", _invokeTime);
    }
    void InvokeGet()
    {
        SceneChange(_sceneName);
    }
}
