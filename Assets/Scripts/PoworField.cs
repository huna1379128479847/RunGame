using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

// プレイヤーがColliderの領域にいるときだけ、ジャンプ力が上がるスクリプト
public class PoworField : MonoBehaviour
{
    GameObject player; // プレイヤーのGameObjectを保持する変数
    [SerializeField] float power; // 力の強さ
    [SerializeField] Vector2 direction; // 力の方向
    [SerializeField] bool isJumpBoost; // ジャンプブーストかどうかを示すフラグ
    float nowPower = 0; // 現在の力の強さ

    // 初期化処理
    private void Start()
    {
        player = SceneChanger.instance.player; // SceneChangerからプレイヤーを取得
        direction = direction.normalized; // 力の方向を正規化（方向だけを保つ）

        // ジャンプブーストの場合、プレイヤーのジャンプ力を増加させる
        if (isJumpBoost)
        {
            nowPower = player.GetComponent<PlayerController>().jumpPow; // 現在のジャンプ力を取得
            power += nowPower; // 力の強さに現在のジャンプ力を加算
        }
    }

    // プレイヤーがトリガーに留まっているときに呼び出されるメソッド
    private void OnTriggerStay2D(Collider2D other)
    {
        // ジャンプブーストの場合
        if (isJumpBoost)
        {
            // プレイヤーのジャンプ力を設定
            player.GetComponent<PlayerController>().jumpPow = power;
            return;
        }

        // プレイヤーがトリガー内にいるとき
        if (other.gameObject == player && MathF.Abs(nowPower) < MathF.Abs(power))
        {
            // 現在の力の強さを増加させる
            nowPower += power / 60;
        }

        // プレイヤーに力を加える
        player.GetComponent<Rigidbody2D>().AddForce(direction * nowPower);
    }

    // プレイヤーがトリガーから出たときに呼び出されるメソッド
    private void OnTriggerExit2D(Collider2D collision)
    {
        // ジャンプブーストの場合
        if (isJumpBoost)
        {
            // プレイヤーのジャンプ力を元に戻す
            player.GetComponent<PlayerController>().jumpPow = nowPower;
        }

        // プレイヤーがトリガーから出たとき
        if (collision.gameObject == player)
        {
            // 現在の力の強さをリセット
            nowPower = 0;
        }
    }
}
