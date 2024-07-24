using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_new : PlayerController
{
    [SerializeField] AudioClip SE_jump; // インスペクターから設定
    AudioSource audioSource;
    private Animator animator;
    // アニメーションの設定
    // SetBool"isWalk"    = 歩くアニメーション
    // SetBool"isJump"    = ジャンプアニメーション
    // SetBool"isFalling" = 落下中アニメーション
    // SetBool"isLanding" = 着地アニメーション
    // trueでアニメーションが再生される falseでアニメーションが再生されなくなる

    override protected void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        this.audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        this.animator.SetBool("isWalk", true);
        if (Input.GetKeyDown(KeyCode.Space) && onFloor && !gameover)
        {
            audioSource.PlayOneShot(SE_jump);
            rbody.AddForce(transform.up * jumpPow);
            onFloor = false;
        }

        if (this.rbody.velocity.y > 0) // プレイヤーが上昇しているとき
        {
            this.animator.SetBool("isJump", true);
            this.animator.SetBool("isWalk", false);
        }
        else
        {
            this.animator.SetBool("isJump", false);
            this.animator.SetBool("isWalk", true);
        }

        if (this.rbody.velocity.y < 0) // プレイヤーが下降しているとき
        {
            this.animator.SetBool("isFalling", true);
            this.animator.SetBool("inWalk", false);
        }
        else
        {
            this.animator.SetBool("isFalling", false);
            this.animator.SetBool("isWalk", true);
        }
        if (this.rbody.velocity.y == 0) // プレイヤーが着地したとき
        {
            StartCoroutine(Landing());
        }
    }



    IEnumerator Landing() // 一瞬だけ着地アニメーションをする
    {
        this.animator.SetBool("isLanding", true);
        this.animator.SetBool("inWalk", false);
        yield return new WaitForSeconds(0.1f);
        this.animator.SetBool("isLanding", false);
        this.animator.SetBool("isWalk", true);
    }
}

