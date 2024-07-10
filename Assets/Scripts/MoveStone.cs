using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.Tilemaps;
using UnityEngine;
public class MoveStone : Stone
{
    [SerializeField] float speed;
    protected override bool PostTick()
    {
        Vector2 vector = transform.position;
        gameObject.transform.position = new Vector2 (vector.x+speed*Time.deltaTime, 0f);
        return base.PostTick();
    }
}
