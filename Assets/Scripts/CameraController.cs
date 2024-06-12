using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private Vector2 defaltTargetPos;
    [SerializeField] private float deltaX;

    private void Start()
    {
        defaltTargetPos = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent == null)
        {
            Vector2 vector2 = target.transform.position;
            if (System.Math.Abs(defaltTargetPos.x - vector2.x) > deltaX)
            {
                transform.parent = target.transform;
            }
        }
        if (transform.parent != null)
        {
            Quaternion quaternion = target.transform.rotation;
            float x = quaternion.x;
            float y = quaternion.y;
            transform.rotation = Quaternion.Euler(-x, -y, 0);
        }
    }
}
