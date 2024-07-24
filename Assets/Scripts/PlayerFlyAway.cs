using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class PlayerFlyAway : MonoBehaviour
{
    public float flySpeed = 5f;      // 飛ぶスピード
    private bool isFlying = false;
    public float spin = -10f;
    private GameObject player; // 動かしたいプレイヤーオブジェクト
    private Rigidbody2D rb; // リジッドボディ
    Collider2D col2D; // コライダーの設定を可能にする
    private BoxCollider2D boxcol2D; // ボックスコライダー
    private CapsuleCollider2D capcol2D; // カプセルコライダー
    [SerializeField] AudioClip SE_damege; // インスペクターからSEを設定
    AudioSource audioSource;
    private Animator animator; // 

    void Start()
    {
        player = this.gameObject; // アタッチされているオブジェクトのgameobjectを取得
        rb = GetComponent<Rigidbody2D>();                  // アタッチされたリジッドボディコンポーネントを取得
        this.boxcol2D = GetComponent<BoxCollider2D>();     // アタッチされたボックスコライダーコンポーネントを取得
        this.capcol2D = GetComponent<CapsuleCollider2D>(); // アタッチされたカプセルコライダーコンポーネントを取得
        this.audioSource = GetComponent<AudioSource>();    // アタッチされたオーディオソースコンポーネントを取得
        animator = GetComponent<Animator>();               // アタッチされたアニメーターコンポーネントを取得
    }

    void Update()
    {
        if (isFlying == true) // フラグが立っていたら
        {
            player.transform.Rotate(0,0,spin);  // プレイヤーを回転させる
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // 敵オブジェクトに触れたら
        {
            audioSource.PlayOneShot(SE_damege); // 攻撃を食らった音を再生
            rb.velocity = Vector2.zero;  // 衝突時の速度をリセット
            StartCoroutine(GameOverFly());
        }
    }

    IEnumerator GameOverFly() // 敵に当たったとき、プレイヤーが回転しながら画面上部に飛んでいく
    {
        this.animator.SetBool("Gameover", true);// ゲームオーバーのアニメーションに移行
        rb.constraints = RigidbodyConstraints2D.FreezePosition; // リジットボディのX,y軸を固定
        this.boxcol2D.isTrigger = true; // boxcol2Dのトリガー化を有効にする
        this.capcol2D.isTrigger = true; // capcol2Dのトリガー化を有効にする
        yield return new WaitForSeconds(1f);

        // 画面上部に飛んでいく
        player.transform.DOMove(new Vector3(player.transform.position.x , player.transform.position.y + 20f, player.transform.position.z),3f);
        isFlying = true; // プレイヤーが回転するフラグを立てる
    }
}
