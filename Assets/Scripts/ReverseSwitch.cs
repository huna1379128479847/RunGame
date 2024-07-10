using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ReverseSwitch : MonoBehaviour
{
    PlayerController controller;
    private void Start()
    {
        controller = SceneChanger.instance.player.GetComponent<PlayerController>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (SceneChanger.instance.player == collision.gameObject)
        {

            controller.speed *= -1;
            if (controller.speed >= 0)
            {
                SceneChanger.instance.player.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            else
            {
                SceneChanger.instance.player.transform.rotation = new Quaternion(0, 180, 0, 0);
            }
        }
    }
}
