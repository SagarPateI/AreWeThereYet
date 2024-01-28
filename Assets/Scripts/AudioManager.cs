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
        InvokeRepeating("MainTheme", 0f, 17f);
    }

    void MainTheme()
    {
<<<<<<< Updated upstream
        timer = timer - Time.deltaTime;
=======
        if (timer == 0)
        {
            Opening.Stop();
            MainLoop.Play();
        }
        timer--;
>>>>>>> Stashed changes
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
