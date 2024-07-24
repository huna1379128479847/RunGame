using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_new : PlayerController
{
    [SerializeField] AudioClip SE_jump; // インスペクターから設定
    AudioSource audioSource; // オーディオソースコンポーネント
    private Animator animator; // アニメーターコンポーネント
    // アニメーションの設定
    // SetBool"isWalk"    = 歩くアニメーション
    // SetBool"isJump"    = ジャンプアニメーション
    // SetBool"isFalling" = 落下中アニメーション
    // SetBool"isLanding" = 着地アニメーション
    // trueでアニメーションが再生される falseでアニメーションが再生されなくなる

    override protected void Start()
    {
        base.Start();
        this.audioSource = GetComponent<AudioSource>(); // アタッチされたオーディオソースコンポーネントを取得
        animator = GetComponent<Animator>(); // アタッチされたアニメーターコンポーネントを取得

    }

    void Update()
    {
        if (onFloor == true)
        {
            this.animator.SetBool("isWalk", true); // 歩くアニメーションを常に設定（他のアニメーションが優先される場合は上書きされる）
        }

        // ジャンプ処理
        if (Input.GetKeyDown(KeyCode.Space) && onFloor && !gameover)
        {
            audioSource.PlayOneShot(SE_jump); // ジャンプ音を再生
            rbody.AddForce(transform.up * jumpPow); // 上方向に力を加えてジャンプ
            onFloor = false; // プレイヤーが地面にいない状態に設定
        }

        // 上昇中のアニメーション設定
        if (this.rbody.velocity.y > 0 && onFloor == false) // プレイヤーが上昇していて、地面にいないとき
        {
            this.animator.SetBool("isJump", true);
            this.animator.SetBool("isWalk", false);
        }
        else
        {
            this.animator.SetBool("isJump", false);
            this.animator.SetBool("isWalk", true);
        }

        // 下降中のアニメーション設定
        if (this.rbody.velocity.y < 0) // プレイヤーが下降しているとき
        {
            this.animator.SetBool("isFalling", true);
            this.animator.SetBool("isWalk", false);
        }
        else
        {
            this.animator.SetBool("isFalling", false);
            this.animator.SetBool("isWalk", true);
        }

        // 着地アニメーションの設定
        if (this.rbody.velocity.y == 0) // プレイヤーが着地したとき
        {
            StartCoroutine(Landing()); // 一瞬だけ着地アニメーションを再生
        }
    }



    IEnumerator Landing() // 一瞬だけ着地アニメーションをするコルーチン
    {
        this.animator.SetBool("isLanding", true);
        this.animator.SetBool("isWalk", false);
        yield return new WaitForSeconds(0.1f); // 0.1秒待機
        this.animator.SetBool("isLanding", false);
        this.animator.SetBool("isWalk", true);
    }
}

