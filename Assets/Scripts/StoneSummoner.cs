using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSummoner : MonoBehaviour
{
    [SerializeField] GameObject stone; // シーン内で出現させる石のGameObject
    string playerTag = "Player"; // プレイヤーオブジェクトのタグ

    // トリガーに他のコライダーが入ったときに呼び出されるメソッド
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 衝突したオブジェクトのタグがプレイヤーである場合
        if (collision.tag == playerTag)
        {
            // 石のGameObjectをアクティブにする
            stone.SetActive(true);
        }
    }
}