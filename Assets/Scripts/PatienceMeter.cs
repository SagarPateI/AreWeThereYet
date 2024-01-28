using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PatienceMeter : MonoBehaviour
{
    private Slider slider;
    public float FillSpeed = 0.05f;
    public float startingPatience = 1f;
    public float hitPenalty = 0.2f;
    public float stfuPenalty = 0.1f;
    public float decreaseRate = 0.01f; // Rate at which patience decreases per second
    //public GameObject switchPlayerScreen;
    private float targetProgress;
    public GameObject scoreManager;
    public float wrongAnswerPenalty = 0.5f; // the penalty for selecting the wrong answer


    void Start()
    {
        slider = GetComponent<Slider>();
        targetProgress = startingPatience;
        UpdatePatienceUI();
    }

    void Update()
    {
        // Decrease patience over time
        targetProgress -= decreaseRate * Time.deltaTime;

        if (slider.value < targetProgress)
        {
            slider.value += FillSpeed * Time.deltaTime;
        }
        else if (slider.value > targetProgress)
        {
            slider.value -= FillSpeed * Time.deltaTime;
        }

        // Check if patience has reached zero
        if (slider.value <= 0)
        {
            scoreManager.GetComponent<ScoreScript>().SaveScore();
            //switchPlayerScreen.SetActive(true);

            // PAUSE THE GAME HERE AS WELL
            PlayerPrefs.DeleteKey("BabysitterName");
            SceneManager.LoadScene("EnterNameAgain");
        }
    }

    // Decrease patience when the car hits an object
    public void DecreasePatienceByHit()
    {
        targetProgress -= hitPenalty;
    }

    // Decrease patience when the babysitter tells the kid to STFU
    public void DecreasePatienceBySTFU()
    {
        targetProgress -= stfuPenalty;
    }

    // Update the UI slider to reflect current patience value
    void UpdatePatienceUI()
    {
        slider.value = targetProgress / startingPatience;
    }

    // Used for Score
    // Returns true/false depending on if patience is 0 or not
    public bool isPatienceZero()
    {
        return targetProgress <= 0;
    }

    // decrease patience when the player selects the wrong answer
    public void DecreasePatienceByWrongAnswer()
    {
        targetProgress -= wrongAnswerPenalty;
        // update UI to reflect the change
        UpdatePatienceUI();
    }
}
