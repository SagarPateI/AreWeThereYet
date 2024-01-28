using UnityEngine;
using UnityEngine.UI;

public class PatienceMeter : MonoBehaviour
{
    private Slider slider;
    public float FillSpeed = 0.5f;
    public float startingPatience = 100f;
    public float hitPenalty = 5f;
    public float stfuPenalty = 10f;
    public GameObject switchPlayerScreen;
    private float targetProgress;
    public GameObject scoreManager;

    void Start()
    {
        slider = GetComponent<Slider>();
        targetProgress = startingPatience;
        UpdatePatienceUI();
    }

    void Update()
    {
        if (slider.value < targetProgress)
        {
            slider.value += FillSpeed * Time.deltaTime;
        }
        else if (slider.value > targetProgress)
        {
            slider.value -= FillSpeed * Time.deltaTime;
        }

        // check if patience has reached zero
        if (slider.value <= 0)
        {
            scoreManager.GetComponent<ScoreScript>().SaveScore();
            switchPlayerScreen.SetActive(true);
            // PAUSE THE GAME HERE AS WELL
        }
    }

    // decrease patience when the car hits an object
    public void DecreasePatienceByHit()
    {
        targetProgress -= hitPenalty;
    }

    // decrease patience when the babysitter tells the kid to STFU
    public void DecreasePatienceBySTFU()
    {
        targetProgress -= stfuPenalty;
    }

    // update the UI slider to reflect current patience value
    void UpdatePatienceUI()
    {
        slider.value = targetProgress / startingPatience;
    }

    // used for Score
    // returns true/false depending on if patience is 0 or not
    public bool isPatienceZero()
    {
        return targetProgress <= 0;
    }
}
