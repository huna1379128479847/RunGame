using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSummoner : MonoBehaviour
{
    [SerializeField] GameObject stone;
    string playerTag = "Player";
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            stone.SetActive(true);
        }
    }
}
