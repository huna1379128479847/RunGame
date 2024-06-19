using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BaseBarrier : MonoBehaviour
{
    [SerializeField] protected string checkTag;
    [SerializeField] protected GameObject bird;

    protected void Start()
    {
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
        if (!PostStart())
        {

            Debug.LogError($"Failed Loading in {ObjectName}");
        }
        //処理

        //
        if (!PostStart())
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
        return true;
    }

    virtual protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == checkTag)
        {
            GameOver();
        }
    }

    virtual protected void GameOver()
    {
        bird.GetComponent<PlayerController>().Notify_Gameover();
        Debug.Log("石にぶつかったよ！ゲームオーバー！");
    }
}
