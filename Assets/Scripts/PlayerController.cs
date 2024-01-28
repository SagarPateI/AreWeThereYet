using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D playerRB;
    public Transform finishLine;

    void Start()
    {

    }

    void FixedUpdate()
    {
        // calculate the distance left
        float distanceToFinishLine = Vector3.Distance(transform.position, finishLine.position);

        // update the distance value in PlayerPrefs
        PlayerPrefs.SetFloat("DistanceToFinishLine", distanceToFinishLine);

        playerRB.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, 0, 0);
    }
}
