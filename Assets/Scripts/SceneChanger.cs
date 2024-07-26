using HighElixir;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : SingletonBehavior<SceneChanger>
{
    public GameObject player; // プレイヤーのGameObjectを保持する変数

    override protected void Awake() // Awakeはオブジェクトが有効化されたときに一度だけ実行される
    {
        base.Awake(); // 親クラスのAwakeメソッドを呼び出す
    }

    // このメソッドを呼び出してシーンを変更します。呼び出し方例: "SceneChanger.instance.LoadLevel("SceneName")"
    public void LoadLevel(string sceneName)
    {
        // 指定されたシーンを読み込む
        SceneManager.LoadScene(sceneName);
    }
}