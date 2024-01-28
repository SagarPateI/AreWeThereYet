using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D playerRB;

    void Start()
    {

    }

    void FixedUpdate()
    {
        playerRB.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, 0, 0);
    }
}
