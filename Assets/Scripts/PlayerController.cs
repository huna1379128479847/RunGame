using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpPow = 300f;
    private bool onFloor = true;
    private bool gameover = false;
    [SerializeField] private Rigidbody2D rbody;
    [SerializeField] private GameObject floor;
    [SerializeField] private TMP_Text text;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && onFloor && !gameover)
        {
            rbody.AddForce(transform.up * jumpPow);
            onFloor = false;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject == floor && !onFloor)
        {
            onFloor = true;
        }
    }
    // FixedUpdate ÇÕå≈íËéûä‘Ç≤Ç∆Ç…åƒÇ—èoÇ≥ÇÍÇÈ
    private void FixedUpdate()
    {
        if (!gameover)
        {
            rbody.velocity = new Vector2(speed, rbody.velocity.y);
            text.SetText($"Now Y Pow:{rbody.velocity.y}");
        }
    }

    public void Notify_Gameover()
    {
        gameover = true;
    }
}
