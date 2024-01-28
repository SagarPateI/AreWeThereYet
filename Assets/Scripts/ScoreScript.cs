using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public GameObject patienceMeter;
    private PatienceMeter patienceScript;
    private float score;

    void Start()
    {
        score = 0;
        patienceScript = patienceMeter.GetComponent<PatienceMeter>();
        InvokeRepeating("ScoreTracker", 0f, 1f);
    }

    void ScoreTracker()
    {
        if (patienceMeter != null && patienceScript.IsPatienceEmpty())
        {
            score++;
            Debug.Log(score);
        }
    }

    public void SaveScore()
    {
        using (StreamWriter sw = new StreamWriter(Application.dataPath + "/BabysitterList.txt", true))
        {
            sw.Write("\t" + score + "\n");
            sw.Close();
        }
    }

    public float getScore()
    {
        return score;
    }
}
