using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    float rightleft = 0;
    Rigidbody2D playerRB;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) rightleft = -speed;
        else if (Input.GetKey(KeyCode.RightArrow)) rightleft = speed;
        else rightleft = 0;
        rightleft *= Time.deltaTime;
        Vector3 pMove = new Vector3(rightleft, 0, 0);
        playerRB.MovePosition(transform.position + pMove);
    }
}
