using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : BaseBarrier// BaseBarrierクラスを継承
{
    // 継承先クラス（BaseBarrier）のPostStartメソッドをオーバーライド
    override protected bool PostStart()
    {
        return base.PostStart(); // 基底クラスのPostStartメソッドを呼び出して処理を実行
    }

    // 継承先クラス（BaseBarrier）のGameOverメソッドをオーバーライド
    protected override void GameOver()
    {
        Debug.Log("石に当たってゲームオーバー！"); // ゲームオーバー時のデバッグメッセージを表示
        
        base.GameOver();// 基底クラスのGameOverメソッドを呼び出して親クラスの処理も実行
    }
}