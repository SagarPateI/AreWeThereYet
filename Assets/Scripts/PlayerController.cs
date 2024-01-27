using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    float rightleft = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) rightleft = -speed;
        else if (Input.GetKey(KeyCode.RightArrow)) rightleft = speed;
        else rightleft = 0;
        transform.Translate(rightleft * Time.deltaTime, 0, 0);
    }
}
