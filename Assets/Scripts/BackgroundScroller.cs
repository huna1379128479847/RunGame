using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    // カメラのTransform
    public Transform cameraTransform;
    
    // 背景のTransform
    public Transform background;
    
    // 背景のスクロール速度（プレイヤーの動きに対する比率）
    public float scrollSpeed = 0.5f;
    
    // プレイヤーの初期位置
    private Vector3 startPosition;

    // 背景の初期位置
    private Vector3 backgroundStartPosition;

    void Start()
    {
        // プレイヤーと背景の初期位置を記録
        startPosition = cameraTransform.position;
        backgroundStartPosition = background.position;
    }

    void Update()
    {
        // プレイヤーの移動量を計算
        float distance = cameraTransform.position.x - startPosition.x;
        
        // 背景の新しい位置を計算
        Vector3 newBackgroundPosition = backgroundStartPosition + new Vector3(distance * scrollSpeed, 0, 0);
        
        // 背景の位置を更新
        background.position = newBackgroundPosition;
    }
}
