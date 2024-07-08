using HighElixir;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : SingletonBehavior<SceneChanger>
{
    // Start is called before the first frame update
    override protected void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    // If you want call to this method, you should write to:"SceneChanger.instance.LoadLevel("SceneName")".
    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
