using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DistanceMeter : MonoBehaviour
{
    private Slider slider;
    public float FillSpeed = 0.05f;
    public float startingDistance = 100f; // Starting distance value
    public float decreaseRate = 0.1f; // Rate at which distance decreases per second
    private float targetDistance;

    void Start()
    {
        slider = GetComponent<Slider>();
        targetDistance = startingDistance;
        UpdateDistanceUI();
    }

    void Update()
    {
        // Decrease distance over time
        targetDistance -= decreaseRate * Time.deltaTime;

        // Update the UI slider to reflect current distance value
        UpdateDistanceUI();

        // Check if distance has reached zero
        if (targetDistance <= 0)
        {
            // Handle game over or any other logic when distance reaches zero
            SceneManager.LoadScene("GameOverScene");
        }
    }

    // Update the UI slider to reflect current distance value
    void UpdateDistanceUI()
    {
        slider.value = targetDistance / startingDistance;
    }
}
