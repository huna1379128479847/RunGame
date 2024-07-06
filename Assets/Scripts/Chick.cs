using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chick : BaseBarrier
{
    override protected void GameOver()
    {
        Debug.Log("ひよこちゃんを助けたよ！ゲームクリアー！");
        base.GameOver();
    }
}
