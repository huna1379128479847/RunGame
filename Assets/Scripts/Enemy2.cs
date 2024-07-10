using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : BaseBarrier
{
   [SerializeField] float jump;
   [SerializeField] float speed;
   [SerializeField] float maxJumpHeight = 5f; // 最大ジャンプ高度
    bool onFloor;
    float time;
    Rigidbody2D rb;
    protected override bool PostStart()
    {
        rb= GetComponent<Rigidbody2D>();
        return base.PostStart();
    }
    protected override bool PostTick()
    {
        if(onFloor){
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse); // ジャンプ時にインパルスを使用
            onFloor = false;
            time = 4;
        }else{
            time -= Time.deltaTime;
        }
        if (time < 0){
            onFloor = true;
        }
        rb.velocity  = new Vector2(speed, Mathf.Clamp(rb.velocity.y, -maxJumpHeight, maxJumpHeight)); // ジャンプの高度を制限
        return base.PostTick();
    }
}
