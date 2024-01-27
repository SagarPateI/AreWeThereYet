using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject primary;
    private CamControl camscript;
    float randomizer;
    Transform spawnlocation;
    // Start is called before the first frame update
    void Start()
    {
        primary = GameObject.Find("Main Camera");
        camscript = primary.GetComponent<CamControl>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // randomizer = Random.Range(0, 1); // This will always generate 0
        spawnlocation = gameObject.transform;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered");
        randomizer = Random.Range(0, 2);
        if (randomizer == 0)
        {
            Object.Instantiate(camscript.Back1, new Vector3(0, spawnlocation.position.y + 18, 0), transform.rotation);
        }
        if (randomizer == 1)
        {
            Object.Instantiate(camscript.Back2, new Vector3(0, spawnlocation.position.y + 18, 0), transform.rotation);
        }
    }
}
