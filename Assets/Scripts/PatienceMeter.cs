using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PatienceMeter : MonoBehaviour
{
    private Slider slider;
    public float FillSpeed = 0.05f;
    public float maxPatience = 1f; // Maximum patience level
    public float startingPatience = 0f; // Starting patience level (empty)
    public float hitPenalty = 0.2f;
    public float stfuPenalty = 0.1f;
    public GameObject scoreManager;
    public float wrongAnswerPenalty = 0.5f; // Penalty for selecting the wrong answer

    private float targetProgress;

    void Start()
    {
        slider = GetComponent<Slider>();
        targetProgress = startingPatience;
        UpdatePatienceUI();
    }

    void Update()
    {
        // Increase patience over time
        targetProgress += increaseRate * Time.deltaTime;

        // Clamp the target progress within the limits
        targetProgress = Mathf.Clamp(targetProgress, startingPatience, maxPatience);

        // Update the UI accordingly
        slider.value = Mathf.Lerp(slider.value, targetProgress / maxPatience, FillSpeed * Time.deltaTime);

        // Check if patience has reached maximum
        if (targetProgress >= maxPatience)
        {
            // Do something when patience is full
        }

        // Check if patience has reached zero
        if (targetProgress <= startingPatience)
        {
            // Do something when patience is empty
            scoreManager.GetComponent<ScoreScript>().SaveScore();
            PlayerPrefs.DeleteKey("BabysitterName");
            SceneManager.LoadScene("EnterNameAgain");
        }
    }

    // Decrease the patience when the car hits an object
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
        slider.value = targetProgress / maxPatience;
    }

    // Used for Score
    // Returns true/false depending on if patience is empty or not
    public bool IsPatienceEmpty()
    {
        return targetProgress <= startingPatience;
    }

    // Decrease patience when the player selects the wrong answer
    public void DecreasePatienceByWrongAnswer()
    {
        targetProgress -= wrongAnswerPenalty;
        UpdatePatienceUI();
    }
}
