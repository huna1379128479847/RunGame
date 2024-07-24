using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class BaseBarrier : MonoBehaviour
{
    protected GameObject player; // プレイヤーオブジェクトを格納するための変数
    bool isGameover = false;     // ゲームオーバーの状態を表すフラグ
    int count = 5;               // メニューに戻るまでのカウントダウン時間(秒)
    float time;                  // 時間を計測するための変数

    protected void Start()
    {
        player = SceneChanger.instance.player; // シーンチェンジャーからプレイヤーオブジェクトを取得
        string ObjectName = gameObject.name;   // オブジェクト名を取得
        if (!PostStart())
        {

            Debug.LogError($"Failed initializing in {ObjectName}"); // 初期化に失敗した場合のエラーログ
        }
        
        // 追加の処理
        
        if (!PostStart())
        {
            Debug.LogError($"Failed initializing in {ObjectName}"); // 初期化に失敗した場合のエラーログ
        }
    }
    virtual protected bool PreStart() // 子クラス独自の初期化処理を行う。エラーが発生した場合はfalseを返す。
    {
        return true;
    }
    virtual protected bool PostStart() // 子クラス独自の初期化処理を行う。エラーが発生した場合はfalseを返す。
    {
        return true;
    }


    virtual protected void Update()
    {
        string ObjectName = gameObject.name; // オブジェクト名を取得
        if (!PreTick())
        {

            Debug.LogError($"Failed Loading in {ObjectName}"); // 更新処理に失敗した場合のエラーログ
        }
        
        // 追加の処理

        if (!PostTick())
        {
            Debug.LogError($"Failed Loading in {ObjectName}"); // 更新処理に失敗した場合のエラーログ
        }
    }

    virtual protected bool PreTick() // 子クラス独自の処理を書く エラーが発生した場合falseを返す
    {
        return true;
    }
    virtual protected bool PostTick()
    {
        if (isGameover && count >= 0)
        {
            if (time >= 1)
            {
                time = 0;
                Debug.Log($"メニューに戻るまで:{count}"); // メニューに戻るまでのカウントダウンを表示
                count--;
            }
            if (count < 0)
            {
                count = -1;
                SceneChanger.instance.LoadLevel("Menu"); // カウントダウンが終了したらメニューに戻る
            }
        }
        time += Time.deltaTime; // 経過時間を加算
        return true;
    }

    // プレイヤーと衝突したときの処理
    virtual protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            GameOver(); // ゲームオーバー処理を呼び出す
        }
    }

    // プレイヤーとトリガー衝突したときの処理
    virtual protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            GameOver(); // ゲームオーバー処理を呼び出す
        }
    }

    // ゲームオーバー時の処理
    virtual protected void GameOver()
    {
        player.GetComponent<PlayerController>().Notify_Gameover(); // プレイヤーにゲームオーバーを通知
        isGameover = true; // ゲームオーバーの状態に設定
    }
}
