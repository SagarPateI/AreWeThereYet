using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    float rightleft = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) rightleft += -1 * speed;
        if (Input.GetKey(KeyCode.RightArrow)) rightleft += 1 * speed;
        rightleft *= Time.deltaTime;
        transform.Translate(rightleft, 0, 0);
    }
}
