using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject primary;
    private CamControl camscript;
    float randomizer;
    float roadstate;
    Transform spawnlocation;
    // Start is called before the first frame update
    void Start()
    {
        primary = GameObject.Find("Main Camera");
        camscript = primary.GetComponent<CamControl>();
        // randomizer = Random.Range(0, 15); // This will randomly decide when the road changes between lanes
        randomizer = Random.Range(0, 3);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        spawnlocation = gameObject.transform;
        roadstate = camscript.roadstate;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Triggered: " + randomizer);
            if (randomizer == 2 && roadstate == 1)
            {
                Object.Instantiate(camscript.Back2, new Vector3(0, spawnlocation.position.y + 36, 0), transform.rotation);
                camscript.roadstate = 2;
            }
            else if (randomizer == 1 && roadstate == 2)
            {
                Object.Instantiate(camscript.Back4, new Vector3(0, spawnlocation.position.y + 36, 0), transform.rotation);
                camscript.roadstate = 1;
            }
            else if (roadstate == 2)
            {
                Object.Instantiate(camscript.Back3, new Vector3(0, spawnlocation.position.y + 36, 0), transform.rotation);
            }
            else
            {
                Object.Instantiate(camscript.Back1, new Vector3(0, spawnlocation.position.y + 36, 0), transform.rotation);
            }
        }
    }
}
