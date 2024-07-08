using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private Vector2 defaltPos;
    [SerializeField] private float deltaX;

    private void Start()
    {
        defaltPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vector2 = target.transform.position;
        if (defaltPos.x < vector2.x)
        {
            transform.position = target.transform.position;
            Vector2 vec = transform.position;
            transform.position = new Vector3(vec.x, defaltPos.y, -10);
        }
    }
}
