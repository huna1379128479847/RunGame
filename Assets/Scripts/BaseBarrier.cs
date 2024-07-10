using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class BaseBarrier : MonoBehaviour
{
    protected GameObject player;
    bool isGameover = false;
    int count = 5;
    float time;

    protected void Start()
    {
        player = SceneChanger.instance.player;
        string ObjectName = gameObject.name;
        if (!PostStart())
        {

            Debug.LogError($"Failed initializing in {ObjectName}");
        }
        //処理

        //
        if (!PostStart())
        {
            Debug.LogError($"Failed initializing in {ObjectName}");
        }
    }
    virtual protected bool PreStart()//子クラス独自の処理を書く エラーが発生した場合falseを返す
    {
        return true;
    }
    virtual protected bool PostStart()
    {
        return true;
    }


    virtual protected void Update()
    {
        string ObjectName = gameObject.name;
        if (!PreTick())
        {

            Debug.LogError($"Failed Loading in {ObjectName}");
        }
        //処理

        //
        if (!PostTick())
        {
            Debug.LogError($"Failed Loading in {ObjectName}");
        }
    }
    virtual protected bool PreTick()//子クラス独自の処理を書く エラーが発生した場合falseを返す
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
                Debug.Log($"メニューに戻るまで:{count}");
                count--;
            }
            if (count < 0)
            {
                count = -1;
                SceneChanger.instance.LoadLevel("Menu");
            }
        }
        time += Time.deltaTime;
        return true;
    }

    virtual protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            GameOver();
        }
    }

    virtual protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            GameOver();
        }
    }
    virtual protected void GameOver()
    {
        player.GetComponent<PlayerController>().Notify_Gameover();
        isGameover = true;
    }
}
