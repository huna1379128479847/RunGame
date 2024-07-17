using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_new : MonoBehaviour
{
    public float speed = 5f;
    public float jumpPow = 300f;
    [SerializeField] private bool onFloor = true;
    private bool gameover = false;
    private Rigidbody2D rbody;
    private Animator animator;
    // アニメーションの設定
    // SetBool"isWalk"    = 歩くアニメーション
    // SetBool"isJump"    = ジャンプアニメーション
    // SetBool"isFalling" = 落下中アニメーション
    // SetBool"isLanding" = 着地アニメーション
    // trueでアニメーションが再生される falseでアニメーションが再生されなくなる

    void Start()
    {
        SceneChanger.instance.player = gameObject;
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        this.animator.SetBool("isWalk", true);
        if (Input.GetKeyDown(KeyCode.Space) && onFloor && !gameover)
        {

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
        if (this.rbody.velocity.y == 0) // プレイヤーが下降しているとき
        {
            StartCoroutine(Landing());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject.tag == "floor")
        {
            onFloor = true;

        }
    }
    // FixedUpdate �͌Œ莞�Ԃ��ƂɌĂяo�����
    private void FixedUpdate()
    {
        if (!gameover)
        {
            rbody.velocity = new Vector2(speed, rbody.velocity.y);
            //text.SetText($"Now Y Pow:{rbody.velocity.y}");
        }
    }

    public void Notify_Gameover()
    {
        gameover = true;
    }

    IEnumerator Landing()
    {
        this.animator.SetBool("isLanding", true);
        this.animator.SetBool("inWalk", false);
        yield return new WaitForSeconds(0.1f);
        this.animator.SetBool("isLanding", false);
        this.animator.SetBool("isWalk", true);
    }
}
