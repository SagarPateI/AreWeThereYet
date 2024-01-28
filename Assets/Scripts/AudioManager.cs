using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioListener listener;
    public AudioSource carHorn;
    public AudioSource carScreech;


    // Start is called before the first frame update
    void Start()
    {
        
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
