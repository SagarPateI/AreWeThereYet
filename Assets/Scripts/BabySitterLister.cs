using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BabySitterLister : MonoBehaviour
{

    public TMP_InputField input;
    private string sitterName;
    public GameObject errorMessage;

    // Start is called before the first frame update
    void Start()
    {
        if(!File.Exists(Application.dataPath + "/BabysitterList.txt"))
        {
            File.Create(Application.dataPath + "/BabysitterList.txt");
        }

        errorMessage.SetActive(false);


    }

    public void addName()
    {
        if(input.text.Length < 11)
        {
            sitterName = input.text;
            Debug.Log(sitterName);
            using (StreamWriter sw = new StreamWriter(Application.dataPath + "/BabysitterList.txt", true))
            {

                sw.Write(sitterName);
                sw.Close();
            }

            SceneManager.LoadScene("TileTest");


        }
        else
        {
            Debug.Log("Error, name must be 10 characters or less");
            Debug.Log("This Error requires an actual Text object in Scene. WIll create once scene is decided");
            errorMessage.SetActive(true);
        }
        
    }

    public void resetList()
    {
        using(StreamWriter sw = new StreamWriter(Application.dataPath+ "/BabysitterList.txt"))
        {
            sw.Close();
        }
    }

    public void printList()
    {
        string currentLine;
        using(StreamReader sr = new StreamReader(Application.dataPath + "/BabysitterList.txt"))
        {
            currentLine = sr.ReadLine();
            while(currentLine != null)
            {
                Debug.Log(currentLine);
                currentLine = sr.ReadLine();
            }
        }
    }

    public void setName(string name)
    {
        name = sitterName;
    }
    
}
