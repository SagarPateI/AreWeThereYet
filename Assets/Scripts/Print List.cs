using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PrintList : MonoBehaviour
{
    public TMP_Text list;
    // Start is called before the first frame update
    void Start()
    {
        string temp;
        string fullList;
        using (StreamReader sr = new StreamReader(Application.dataPath + "/BabysitterList"))
        {
            temp = sr.ReadLine();
            list.text += temp + "\n";

            sr.Close();
        }
    }

}
