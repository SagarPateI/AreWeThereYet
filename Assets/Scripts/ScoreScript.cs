using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public GameObject patienceMeter;
    private PatienceMeter patienceScript;
    private float score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        patienceScript = patienceMeter.GetComponent<PatienceMeter>();
        InvokeRepeating("ScoreTracker", 0f,  1f);
    }

    void ScoreTracker()
    {
        if (!patienceScript.isPatienceZero())
        {
            score++;
        }
        Debug.Log(score);
    }

    void SaveScore()
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
