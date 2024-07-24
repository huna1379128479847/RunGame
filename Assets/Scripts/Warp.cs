using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 導入シーンのテキストの表示のスクリプト
public class Warp : MonoBehaviour
{
    [SerializeField] GameObject target; // プレイヤーがワープするターゲットのGameObject
    [SerializeField] bool isEast; // プレイヤーの向きが東方向かどうかを示すフラグ
    GameObject player; // プレイヤーのGameObject
    PlayerController playerController; // プレイヤーのPlayerControllerコンポーネント

    private void Awake()
    {
        // シーン内のプレイヤーとそのPlayerControllerコンポーネントを取得
        player = SceneChanger.instance.player;
        playerController = player.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // トリガーに衝突したオブジェクトがプレイヤーである場合
        if (collision.gameObject == player)
        {
            // プレイヤーの位置をターゲットの位置に変更
            player.transform.position = target.transform.position;

            // プレイヤーの向きと速度を設定
            if (isEast)
            {
                // 東方向の場合、速度を正にして回転をデフォルトに戻す
                playerController.speed = Mathf.Abs(playerController.speed);
                player.transform.rotation = Quaternion.identity; // (0, 0, 0, 0) の代わりにQuaternion.identityを使用
            }
            else
            {
                // 西方向の場合、速度を負にして回転を180度に設定
                playerController.speed = Mathf.Abs(playerController.speed) * -1;
                player.transform.rotation = Quaternion.Euler(0, 180, 0); // Quaternion(0, 180, 0, 0) の代わりにQuaternion.Eulerを使用
            }
        }
    }
}