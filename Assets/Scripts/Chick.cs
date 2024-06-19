using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chick : BaseBarrier
{
    override protected void GameOver()
    {
        bird.GetComponent<PlayerController>().Notify_Gameover();
        Debug.Log("ひよこちゃんを助けたよ！ゲームクリアー！");
    }
}
