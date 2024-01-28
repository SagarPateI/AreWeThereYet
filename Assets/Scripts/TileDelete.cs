using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDelete : MonoBehaviour
{
    public GameObject camController;
    private bool started = false;
    // Start is called before the first frame update
    void Start()
    {
        camController = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (camController.GetComponent<CamControl>().didstart)
        {
            started = true;
        }
        if(started)
        {
            Destroy(gameObject, 20f);
        }
    }
}
