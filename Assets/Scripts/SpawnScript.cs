using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject primary;
    private CamControl camscript;
    float randomizer;
    float roadstate = 1;
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
        spawnlocation = gameObject.transform;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        // randomizer = Random.Range(0, 15); // This will randomly decide when the road changes between lanes
        randomizer = Random.Range(0, 5);
        Debug.Log("Triggered");
        if (randomizer == 3 && roadstate == 1)
        {
            Object.Instantiate(camscript.Back2, new Vector3(0, spawnlocation.position.y + 41, 0), transform.rotation);
            roadstate = 2;
        }
        else if (roadstate == 2)
        {
            Object.Instantiate(camscript.Back3, new Vector3(0, spawnlocation.position.y + 41, 0), transform.rotation);
        }
        else if (randomizer == 3 && roadstate == 2)
        {
            Object.Instantiate(camscript.Back4, new Vector3(0, spawnlocation.position.y + 41, 0), transform.rotation);
            roadstate = 1;
        }
        else
        {
            Object.Instantiate(camscript.Back1, new Vector3(0, spawnlocation.position.y + 41, 0), transform.rotation);
        }
    }
}
