using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DistanceMeter : MonoBehaviour
{
    private Slider slider;
    public float FillSpeed = 0.05f;
    public float startingDistance = 100f;
    public float decreaseRate = 0.1f;
    private static float targetDistance;

    void Start()
    {
        slider = GetComponent<Slider>();
        targetDistance = startingDistance;
        UpdateDistanceUI();
    }

    void Update()
    {
        targetDistance -= decreaseRate * Time.deltaTime;
        UpdateDistanceUI();
        if (targetDistance <= 0)
        {
            SceneManager.LoadScene("ScoreScreen");
        }
    }
    
    void UpdateDistanceUI()
    {
        slider.value = targetDistance / startingDistance;
    }
}
