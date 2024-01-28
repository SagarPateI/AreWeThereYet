using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PatienceMeter : MonoBehaviour
{
    private Slider slider;
    public float FillSpeed = 0.05f;
    public float maxPatience = 1f;
    public float startingPatience = 0f;
    public float hitPenalty = 0.1f;
    public float stfuPenalty = 0.1f;
    public float increaseRate = 0.01f; // Rate at which patience increases per second
    public GameObject scoreManager;
    public GameObject distanceMeter;
    public float wrongAnswerPenalty = 0.5f; // Penalty for selecting the wrong answer

    public float targetProgress;

    public GameObject camController;
    private bool started = false;

    void Start()
    {
        camController = GameObject.Find("Main Camera");
        slider = GetComponent<Slider>();
        targetProgress = maxPatience;
        UpdatePatienceUI();
    }

    void Update()
    {
        if (camController.GetComponent<CamControl>().didstart)
        {
            started = true;
        }
        if(started)
        {
            targetProgress = Mathf.Clamp(targetProgress, startingPatience, maxPatience);
            targetProgress -= increaseRate * Time.deltaTime;
            slider.value = Mathf.Lerp(slider.value, targetProgress / maxPatience, FillSpeed * Time.deltaTime);
        }

        // Check if patience has reached zero
        if (targetProgress <= startingPatience)
        {
            // Do something when patience is empty
            scoreManager.GetComponent<ScoreScript>().SaveScore();
            distanceMeter.GetComponent<DistanceMeter>().SaveDistance();
            PlayerPrefs.DeleteKey("BabysitterName");
            SceneManager.LoadScene("EnterNameAgain");
        }
    }

    // Decrease the patience when the car hits an object
    public void DecreasePatienceByHit()
    {
        targetProgress -= hitPenalty;
        UpdatePatienceUI();
    }

    // Decrease patience when the babysitter tells the kid to STFU
    public void DecreasePatienceBySTFU()
    {
        targetProgress -= stfuPenalty;
        UpdatePatienceUI();
    }

    // Used for Score
    // Returns true/false depending on if patience is empty or not
    public bool IsPatienceEmpty()
    {
        return targetProgress <= 0;
    }

    // Decrease patience when the player selects the wrong answer
    public void DecreasePatienceByWrongAnswer()
    {
        targetProgress -= wrongAnswerPenalty;
        UpdatePatienceUI();
    }

    // Update the UI slider to reflect current patience value
    void UpdatePatienceUI()
    {
        slider.value = targetProgress / maxPatience;
    }
}
