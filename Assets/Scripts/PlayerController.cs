using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject primary;
    private CamControl camscript;
    public float speed = 5f;
    public Rigidbody2D playerRB;
    public Transform finishLine;
    bool didstart;

    void Start()
    {
        primary = GameObject.Find("Main Camera");
        camscript = primary.GetComponent<CamControl>();
    }

    void FixedUpdate()
    {
        didstart = camscript.didstart;
        // Car only moves when game started
        if (didstart == true)
        {
            playerRB.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, 0, 0);
        }
        // calculate the distance left
        float distanceToFinishLine = Vector3.Distance(transform.position, finishLine.position);

        // update the distance value in PlayerPrefs
        PlayerPrefs.SetFloat("DistanceToFinishLine", distanceToFinishLine);
    }
}
