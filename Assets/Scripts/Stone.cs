using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    [SerializeField] private string checkTag;
    [SerializeField] private GameObject bird;
     private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == checkTag)
        {
            bird.GetComponent<PlayerController>().Notify_Gameover();
            Debug.Log("石にぶつかったよ！ゲームオーバー！");
        }
    }
}
