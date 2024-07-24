using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalController : MonoBehaviour
{
    // 2Dのコライダーが衝突したときに呼び出されるメソッド
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 衝突したオブジェクトがタグ "Player" を持っているかどうかをチェック
        if (collision.gameObject.CompareTag("Player"))
        {
            // "Player" と衝突した場合、"Clear" シーンに遷移する
            SceneManager.LoadScene("Clear");
        }
    }
}