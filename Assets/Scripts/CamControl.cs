using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CamControl : MonoBehaviour
{
    public GameObject Back1;
    public GameObject Back2;
    public float ms;
    float randomizer;

    private bool didstart = true;

    private float size;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(didstart == true)
        {
            transform.Translate(Vector3.up * ms * Time.deltaTime);
        }
    }
}
