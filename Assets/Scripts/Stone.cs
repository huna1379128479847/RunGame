using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : BaseBarrier
{
    override protected bool PostStart()
    {
        return base.PostStart();
    }

    protected override void GameOver()
    {
        Debug.Log("石にぶつかったよ！ゲームオーバー！");
        base.GameOver();
    }
}
