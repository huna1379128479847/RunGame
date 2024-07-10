using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] bool isEast;
    GameObject player;
    PlayerController playerController;
    private void Awake()
    {
        player = SceneChanger.instance.player;
        playerController = player.GetComponent<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            player.transform.position = target.transform.position;
            if (isEast)
            {
                playerController.speed = Mathf.Abs(playerController.speed);
                player.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            else
            {
                playerController.speed = Mathf.Abs(playerController.speed) * -1;
                player.transform.rotation = new Quaternion(0, 180, 0, 0);
            }
        }
    }
}
