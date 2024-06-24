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

    // �g�p����Ƃ��́uSceneChanger.instance.LoadLevel(�ړ��������V�[���̖��O)�v�ŌĂяo������
    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
