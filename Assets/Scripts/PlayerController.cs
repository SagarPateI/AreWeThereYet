using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D playerRB;
    public GameObject patienceMeter;
    private PatienceMeter patienceMeterCode;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        patienceMeterCode = patienceMeter.GetComponent<PatienceMeter>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0f).normalized;
        playerRB.velocity = movement * speed;
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
