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

    // 使用するときは「SceneChanger.instance.LoadLevel(移動したいシーンの名前)」で呼び出すこと
    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
