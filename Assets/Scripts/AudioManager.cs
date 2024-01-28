using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioListener listener;
    public AudioSource carHorn;
    public AudioSource carScreech;
    public AudioSource MainLoop;
    public AudioSource Opening;
    public float timer = 17f;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void FixedUpdate()
    {
        timer = timer - Time.deltaTime;
    }
    public void playCarHorn()
    {
        carHorn.Play();
    }
    public void playCarScreech()
    {
        carScreech.Play();
    }
}
