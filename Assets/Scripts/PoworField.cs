using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PoworField : MonoBehaviour
{
    GameObject player;
    [SerializeField] float power;
    [SerializeField] Vector2 direction;
    [SerializeField] bool isJumpBoost;
    float nowPower = 0;
    private void Start()
    {
        player = SceneChanger.instance.player;
        direction = direction.normalized;
        if (isJumpBoost)
        {
            nowPower = player.GetComponent<PlayerController>().jumpPow;
            power += nowPower;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (isJumpBoost)
        {
            player.GetComponent<PlayerController>().jumpPow = power;
            return;
        }
        if (other.gameObject == player && MathF.Abs(nowPower) < MathF.Abs(power))
        {
            nowPower += power / 60;
        }
        player.GetComponent<Rigidbody2D>().AddForce(direction * nowPower);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isJumpBoost)
        {
            player.GetComponent<PlayerController>().jumpPow = nowPower;
        }
        if (collision.gameObject == player)
        {
            nowPower = 0;
        }
    }
}