using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D playerRB;
    public GameObject patienceMeter;
    private PatienceMeter patienceMeterCode;

    void Start()
    {
        patienceMeterCode = patienceMeter.GetComponent<PatienceMeter>();
    }

    void FixedUpdate()
    {
        playerRB.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hazard"))
        {
            Debug.Log("Player hit an NPC car!");

            if (patienceMeter != null)
            {
                Debug.Log("subtracted 5%!");
                patienceMeterCode.DecreasePatienceByHit();
            }
        }
    }
}
