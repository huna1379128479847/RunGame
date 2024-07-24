using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : BaseBarrier
{
    [SerializeField] float jump;  // ジャンプ力
    [SerializeField] float speed; // 移動速度
    [SerializeField] float maxJumpHeight = 5f; // 最大ジャンプ高度
    bool onFloor;   // 敵が地面にいるかどうかのフラグ
    float time;     // ジャンプのクールダウンタイム
    Rigidbody2D rb; // 敵のRigidbody2Dコンポーネント

    protected override bool PostStart()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2Dコンポーネントを取得
        return base.PostStart();          // 基底クラスのPostStartメソッドを呼び出す
    }

    protected override bool PostTick()
    {
        if (onFloor)
        {
            // 地面にいる場合、ジャンプを実行
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse); // ジャンプ時にインパルスを使用
            onFloor = false; // ジャンプ中にフラグをオフにする
            time = 4; // クールダウンタイムを設定
        }
        else
        {
            // クールダウンタイムを減少させる
            time -= Time.deltaTime;
        }

        // クールダウンタイムが終了したら、地面にいるフラグをオンにする
        if (time < 0)
        {
            onFloor = true;
        }

        // 敵の速度を設定し、ジャンプの高度を制限
        rb.velocity = new Vector2(speed, Mathf.Clamp(rb.velocity.y, -maxJumpHeight, maxJumpHeight));

        return base.PostTick(); // 基底クラスのPostTickメソッドを呼び出す
    }
}