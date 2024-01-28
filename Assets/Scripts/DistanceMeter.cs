using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class DistanceMeter : MonoBehaviour
{
    private Slider slider;
    public float FillSpeed = 0.05f;
    public float startingDistance = 100f;
    public float decreaseRate = 0.1f;
    private float targetDistance;
    private bool started = false;

    public GameObject camController;

    void Start()
    {
        
        slider = GetComponent<Slider>();

        if (!File.Exists(Application.dataPath + "/distanceTracker.txt"))
        {
            File.Create(Application.dataPath + "/distanceTracker.txt");
            using (StreamWriter sw = new StreamWriter(Application.dataPath + "/distanceTracker.txt"))
            {
                sw.WriteLine(100);
                sw.Close();
            }

        }
        using(StreamReader sr = new StreamReader(Application.dataPath + "/distanceTracker.txt"))
        {
           string temp;
           temp = sr.ReadLine();
            try
            {
                if (float.Parse(temp) == 0)
                {
                    targetDistance = 100f;
                }
                else
                {
                    targetDistance = float.Parse(temp);
                }
            }
            catch 
            {
                Debug.Log("Error, File has beem messed with");
            }
            finally
            {
                sr.Close();
            }

                    
        }
        
        UpdateDistanceUI();
    }

    void Update()
    {
        if (camController.GetComponent<CamControl>().didstart)
        {
            started = true;
        }

        if (started)
        {
            targetDistance -= decreaseRate * Time.deltaTime;

            UpdateDistanceUI();
            if (targetDistance <= 0)
            {
                SceneManager.LoadScene("ScoreScreen");
            }
        }

    }

    void UpdateDistanceUI()
    {
        slider.value = targetDistance / 100f;

    }

    public void SaveDistance()
    {
        using (StreamWriter sw = new StreamWriter(Application.dataPath + "/distanceTracker.txt"))
        {
            sw.WriteLine(targetDistance);
            sw.Close();
        }
    }
}
