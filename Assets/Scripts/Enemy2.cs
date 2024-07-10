using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : BaseBarrier
{
   [SerializeField] float jump;
   [SerializeField] float speed;
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
            rb.AddForce(transform.up * jump);
            onFloor = false;
            time = 4;
        }else{
            time -= Time.deltaTime;
        }
        if (time < 0){
            onFloor = true;
        }
        rb.AddForce(new Vector2(speed*Time.deltaTime,0f));
        return base.PostTick();
    }
}
