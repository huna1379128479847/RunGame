using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [SerializeField] private bool lockYPos = true; // カメラのY座標をロックするかどうか
    [SerializeField] private GameObject target;    // カメラが追従するターゲットオブジェクト
    private Vector2 defaltPos;                     // カメラの初期位置
    [SerializeField] private float deltaX;         // カメラのX座標の差分
    private float deltaY;                          // カメラのY座標の差分

    private void Awake() // Awakeはオブジェクトが有効化されたときに一度だけ実行される
    {
        defaltPos = transform.position; // カメラの初期位置を取得
        deltaY = defaltPos.y - target.transform.position.y; // カメラとターゲットのY座標の差分を計算
    }

    // 毎フレーム呼び出される更新処理
    void Update()
    {
        Vector2 vector2 = target.transform.position; // ターゲットの位置を取得
        Vector2 cameraVec = transform.position;      // カメラの現在位置を取得
        if (defaltPos.x < vector2.x)                 // ターゲットが初期位置より右に移動した場合
        {
            transform.position = target.transform.position; // カメラの位置をターゲットに追従させる
            Vector2 vec = transform.position;               // 追従後のカメラ位置を取得

            if (!lockYPos) // Y座標のロックが解除されている場合
            {
                transform.position = new Vector3(vec.x, vec.y + deltaY, -10); // カメラのY座標をターゲットに合わせる
            }
            else           // Y座標がロックされている場合
            {
                transform.position = new Vector3(vec.x, defaltPos.y, -10);    // カメラのY座標を初期位置に固定
            }
        }
    }
}