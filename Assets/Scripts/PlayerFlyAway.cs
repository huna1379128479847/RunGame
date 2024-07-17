using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlyAway : MonoBehaviour
{
    public float flySpeed = 5f;      // 飛ぶスピード
    private bool isFlying = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isFlying)
        {
            rb.velocity = Vector2.up * flySpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // 敵に衝突したら飛ぶ
            isFlying = true;
            rb.velocity = Vector2.zero;  // 衝突時の速度をリセット
        }
    }
}
