
using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreListScript : MonoBehaviour
{
    public TMP_Text list;
    // Start is called before the first frame update
    void Start()
    {
        string temp;

        using (StreamReader sr = new StreamReader(Application.dataPath + "/BabysitterList.txt"))
        {

            temp = sr.ReadLine();
            while(temp != null)
            {
                list.text += temp + "\n";
                temp = sr.ReadLine();
            }

            sr.Close();
        }
    }

}

