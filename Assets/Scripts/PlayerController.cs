using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public GameObject patienceMeter;
    private PatienceMeter patienceMeterCode;

    void Start()
    {
        patienceMeterCode = patienceMeter.GetComponent<PatienceMeter>();
    }

    void FixedUpdate()
    {
        float rightleft = 0;
        if (Input.GetKey(KeyCode.LeftArrow)) rightleft += -1;
        if (Input.GetKey(KeyCode.RightArrow)) rightleft += 1;
        rightleft *= speed;
        rightleft *= Time.deltaTime;
        transform.Translate(rightleft, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hazard"))
        {
            Debug.Log("Player hit an NPC car!");

            //if (patienceMeter != null)
            //{
            Debug.Log("subtracted 5%!");
            patienceMeterCode.DecreasePatienceByHit();
            //}
        }
    }
}

//if (collision.gameObject.tag == "MyTag")
