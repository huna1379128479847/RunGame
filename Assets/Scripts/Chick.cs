using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chick : BaseBarrier // BaseBarrierクラスを継承
{
    override protected void GameOver()// BaseBarrierクラスのGameOverメソッドをオーバーライド
    {
        Debug.Log("ゲームオーバー！ チックキャラクターの処理が実行されました！"); // ゲームオーバー時のデバッグメッセージを表示

        base.GameOver();// 継承先クラス（BaseBarrier）のGameOverメソッドを呼び出す
    }
}
