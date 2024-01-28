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
        InvokeRepeating("MainTheme", 0f, 1f);
    }

    void MainTheme()
    {
        if (timer == 0)
        {
            Opening.Stop();
            MainLoop.Play();
            MainLoop.mute = false;
            
        }
        timer--;
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
