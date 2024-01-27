using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PatienceMeter : MonoBehaviour
{
    public float startingPatience = 100f;
    public float hitPenalty = 5f;
    public float stfuPenalty = 10f;
    // the screen prompting player switch
    public GameObject switchPlayerScreen;
    // the UI slider representing patience meter
    public Slider patienceSlider; 
    private float currentPatience;
    public GameObject scoreManager;


    void Start()
    {
        currentPatience = startingPatience;
        UpdatePatienceUI();
    }

    // decrease patience when the car hits an object
    public void DecreasePatienceByHit()
    {
        currentPatience -= hitPenalty;
        CheckPatience();
        UpdatePatienceUI();
    }

    // decrease patience when the babysitter tells the kid to STFU
    public void DecreasePatienceBySTFU()
    {
        currentPatience -= stfuPenalty;
        CheckPatience();
        UpdatePatienceUI();
    }

    // check if patience has reached zero
    void CheckPatience()
    {
        if (currentPatience <= 0)
        {
            scoreManager.GetComponent<ScoreScript>().SaveScore();
            switchPlayerScreen.SetActive(true);
            // PAUSE THE GAME HERE AS WELL
        }
    }

    //Used for Score. Returns True/False depending on if patience is 0 or not
    public bool isPatienceZero()
    {
        if(currentPatience <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // update the UI slider to reflect current patience value
    void UpdatePatienceUI()
    {
        patienceSlider.value = currentPatience / startingPatience;
    }
}
