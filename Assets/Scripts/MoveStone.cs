using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public class MoveStone : Stone // Stoneクラスを継承
{
    [SerializeField] float speed; // ストーンの移動速度

    // 基底クラス（Stone）のPostTickメソッドをオーバーライド
    protected override bool PostTick()
    {
        // 現在の位置を取得
        Vector2 vector = transform.position;

        // ストーンの位置を速度に基づいて移動させる
        // X軸方向にspeed * Time.deltaTimeだけ移動し、Y軸は0に固定
        gameObject.transform.position = new Vector2(vector.x + speed * Time.deltaTime, 0f);

        // 基底クラスのPostTickメソッドを呼び出す
        return base.PostTick();
    }
}