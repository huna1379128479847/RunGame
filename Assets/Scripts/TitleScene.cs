using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    // 指定されたシーン名に変更するメソッド
    public void changeScenes(string scenes)
    {
        // SceneManagerを使用して指定されたシーンを読み込む
        SceneManager.LoadScene(scenes);
    }
}