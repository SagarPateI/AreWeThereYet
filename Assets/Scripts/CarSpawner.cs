using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class CarSpawner : MonoBehaviour
{
    public GameObject primary;
    private CamControl camscript;
    float roadstate;
    public int randObj;
    public GameObject NPC;
    public float x;
    public float y;
    public Vector3 originpos;
    public Vector3 distbtwnen;
    public int enemiesperspawn;
    public float spawntime = 2.5f;
    public float yloc;
    public float xloc;
    public GameObject Camera;
    float spawnx;
    bool didstart;
    // Start is called before the first frame update
    void Start()
    {
        primary = GameObject.Find("Main Camera");
        camscript = primary.GetComponent<CamControl>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        didstart = camscript.didstart;
        roadstate = camscript.roadstate;
        originpos = transform.position;
        xloc = transform.position.x;
        yloc = transform.position.y;
        originpos = transform.position;
        enemiesperspawn = UnityEngine.Random.Range(0, 3);
        if(didstart == true)
        {
            spawntime = spawntime - Time.deltaTime;
        }
        if (spawntime <= 0f)
        {
            if(roadstate == 1)
            {
                var r = new Random();
                int gap = r.Next(enemiesperspawn);
                for (int column = 0; column < enemiesperspawn; column++)
                {
                    // randomize spawn location
                    float randomizer = UnityEngine.Random.Range(0f, 15f);
                    if (randomizer > 10)
                    {
                        spawnx = -2.6f;
                    }
                    else if (randomizer > 5)
                    {
                        spawnx = 2.5f;
                    }
                    else
                    {
                        spawnx = 0f;
                    }

                    // calculate position
                    Vector3 spawnPosition = new Vector3(spawnx, yloc, -1);
                    // create new obstacle
                    GameObject newEnemy = Instantiate(NPC, spawnPosition, Quaternion.identity);
                }
            }
            else if (roadstate == 3)
            {
                var r = new Random();
                int gap = r.Next(enemiesperspawn);
                for (int column = 0; column < enemiesperspawn; column++)
                {
                    // randomize spawn location
                    float randomizer = UnityEngine.Random.Range(0f, 25f);
                    if (randomizer > 20)
                    {
                        spawnx = -5.1f;
                    }
                    else if (randomizer > 15)
                    {
                        spawnx = 5.1f;
                    }
                    else if (randomizer > 10)
                    {
                        spawnx = -2.6f;
                    }
                    else if (randomizer > 5)
                    {
                        spawnx = 2.5f;
                    }
                    else
                    {
                        spawnx = 0f;
                    }

                    // calculate position
                    Vector3 spawnPosition = new Vector3(spawnx, yloc, -1);
                    // create new obstacle
                    GameObject newEnemy = Instantiate(NPC, spawnPosition, Quaternion.identity);
                }
            }
            Debug.Log("spawned");
            spawntime = UnityEngine.Random.Range(1f, 1.2f);
        }
    }
    public void Spawn()
    {

    }

}
