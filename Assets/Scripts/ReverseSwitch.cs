using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

// プレイヤーがColliderの領域に入ったとき、プレイヤーの移動が反転するスクリプト
public class ReverseSwitch : MonoBehaviour
{
    PlayerController controller; // プレイヤーのPlayerControllerコンポーネントを保持する変数
    // 初期化処理
    private void Start()
    {
        // SceneChangerからプレイヤーのPlayerControllerコンポーネントを取得
        controller = SceneChanger.instance.player.GetComponent<PlayerController>();
    }

    // トリガーに他のコライダーが入ったときに呼び出されるメソッド
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // 衝突したオブジェクトがプレイヤーの場合
        if (SceneChanger.instance.player == collision.gameObject)
        {
            // プレイヤーの移動速度を反転させる
            controller.speed *= -1;

            // プレイヤーの移動方向に応じて回転を設定
            if (controller.speed >= 0)
            {
                // 速度が0以上の場合（右向き）
                SceneChanger.instance.player.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                // 速度が負の場合（左向き）
                SceneChanger.instance.player.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
}