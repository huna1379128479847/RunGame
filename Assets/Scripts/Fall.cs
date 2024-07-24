using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : BaseBarrier // BaseBarrierクラスを継承
{
    [SerializeField] AudioClip SE_damege; // インスペクターからSEを設定
    AudioSource audioSource;
    
    // BaseBarrierクラスのGameOverメソッドをオーバーライド
    protected override void GameOver()
    {
        // ゲームオーバー時のデバッグメッセージを表示
        Debug.Log("落とし穴に落ちた！ゲームオーバー！");
        
        // 継承先クラス（BaseBarrier）のGameOverメソッドを呼び出す
        base.GameOver();
    }
}