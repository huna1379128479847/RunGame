using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;     // プレイヤーの移動速度
    public float jumpPow = 300f; // ジャンプの力
    [SerializeField] protected bool onFloor = true; // プレイヤーが地面にいるかどうかのフラグ
    protected bool gameover = false; // ゲームオーバー状態を示すフラグ
    protected Rigidbody2D rbody; // プレイヤーのRigidbody2Dコンポーネント

    virtual protected void Start()
    {
        rbody = GetComponent<Rigidbody2D>(); // Rigidbody2Dコンポーネントを取得
        SceneChanger.instance.player = gameObject; // SceneChangerのplayerプロパティに自分自身を設定
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onFloor && !gameover) // スペースキーが押され、プレイヤーが地面におり、ゲームオーバーでない場合
        {
            // プレイヤーを上方向にジャンプさせる
            rbody.AddForce(transform.up * jumpPow); // ジャンプ時に力を加える
            onFloor = false;                        // ジャンプ中は地面にいないと設定
        }
        // ゲームオーバーになるとキーを押してもジャンプができなくなる
    }

    // 2Dのコライダーが衝突したときに呼び出されるメソッド
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.tag == "floor") // 衝突したオブジェクトのタグが "floor" の場合
        {
            onFloor = true; // プレイヤーが地面にいると設定
        }
    }

    // FixedUpdateは物理演算の更新ごとに呼び出される
    private void FixedUpdate()
    {
        if (!gameover)
        {
            rbody.velocity = new Vector2(speed, rbody.velocity.y); // プレイヤーの移動速度を設定（Y軸の速度は変更しない）
        }
        // ゲームオーバーになるとプレイヤーの移動が停止する
    }

    // ゲームオーバー状態を通知するメソッド
    public void Notify_Gameover()
    {
        gameover = true; // ゲームオーバー状態を設定
    }
}