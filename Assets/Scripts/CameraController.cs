using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [SerializeField] private bool lockYPos = true;
    [SerializeField] private GameObject target;
    private Vector2 defaltPos;
    [SerializeField] private float deltaX;
    private float deltaY;

    private void Awake()
    {
        defaltPos = transform.position;
        deltaY = defaltPos.y - target.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vector2 = target.transform.position;
        Vector2 cameraVec = transform.position;
        if (defaltPos.x < vector2.x)
        {
            transform.position = target.transform.position;
            Vector2 vec = transform.position;
            if (!lockYPos)
            {
                transform.position = new Vector3(vec.x, vec.y+deltaY, -10);
            }
            else
            {
                transform.position = new Vector3(vec.x, defaltPos.y, -10);
            }
        }
    }
}
