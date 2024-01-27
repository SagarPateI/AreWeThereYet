using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDelete : MonoBehaviour
{
    public GameObject tile;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(tile, 8f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
