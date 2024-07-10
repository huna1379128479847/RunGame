using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Menu_SceneChenge_s3 : MonoBehaviour , IPointerClickHandler // IPointerClickHandlerはオブジェクトがクリックされたときに呼び出されるようになる
{
    // Physics2DRaycasterをカメラに追加しておく
    public void OnPointerClick(PointerEventData chengeScene_Title) // オブジェクトがクリックされた時
    {
        print($"オブジェクト{name}がクリックされた。");
        SceneManager.LoadScene("GameStage3"); // ステージ3シーンに移動する
    }
}