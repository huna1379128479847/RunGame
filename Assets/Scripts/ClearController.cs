using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    
    void Start()
    {
        // ゲームオブジェクトにアタッチされているButtonコンポーネントを取得し、
        // そのボタンがクリックされたときにClearGameメソッドを呼び出すリスナーを追加
        gameObject.GetComponent<Button>().onClick.AddListener(ClearGame);
    }


    void ClearGame() // ボタンがクリックされたときに呼び出されるメソッド
    {
        SceneManager.LoadScene("Menu"); // シーンを"Menu"シーンに切り替える
    }
}