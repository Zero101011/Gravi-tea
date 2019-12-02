using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{

    public float fLimit = 0.5f;
    public float rLimit = 0f;
    public float speed = 2.0f;
    public Vector3 movement;
    private int direction = 1;

    void Update()
    {
        if (transform.position.z > fLimit)
        {
            direction = -1;
        }
        else if (transform.position.z < rLimit)
        {
            direction = 1;
        }
        movement = new Vector3(0, 0, 1) * direction * speed * Time.deltaTime;
        transform.Translate(movement);
    }
}