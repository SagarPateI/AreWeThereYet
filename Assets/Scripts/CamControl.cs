using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CamControl : MonoBehaviour
{
    public GameObject Back1;
    public GameObject Back2;
    public GameObject Back3;
    public GameObject Back4;
    public float ms;

    public bool didstart = true;

    private float size;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(didstart == true)
        {
            transform.Translate(Vector3.up * ms * Time.deltaTime);
        }
    }
}
