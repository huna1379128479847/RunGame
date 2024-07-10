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
    float nowPower = 0;
    private void Start()
    {
        player = SceneChanger.instance.player;
        direction = direction.normalized;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == player && MathF.Abs(nowPower) < MathF.Abs(power))
        {
            nowPower += power / 60;
        }
        player.GetComponent<Rigidbody2D>().AddForce(direction*nowPower);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            nowPower = 0;
        }
    }
}