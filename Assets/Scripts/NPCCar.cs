using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCar: MonoBehaviour
{
    public GameObject patienceMeter;
    private PatienceMeter patienceMeterCode;
    public float speed = 5f;
    public GameObject audioManager;
    private AudioManager audioScript;

    void Start()
    {
        patienceMeter = GameObject.Find("Patience Slider");
        patienceMeterCode = patienceMeter.GetComponent<PatienceMeter>();
        audioManager = GameObject.Find("Audio Manager");
        audioScript = audioManager.GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == ("Player"))
        {
            Debug.Log("Player hit an NPC car!");
            audioScript.playCarHorn();
            audioScript.playCarScreech();

            if (patienceMeter != null)
            {
                Debug.Log("subtracted patience!");
                patienceMeterCode.DecreasePatienceByHit();
            }
            Destroy(gameObject);
        }
    }
}