using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayText : MonoBehaviour
{

    public TextMeshProUGUI objText;
    public TMP_InputField display;

    // Start is called before the first frame update
    void Start()
    {
        objText.text = PlayerPrefs.GetString("userName");
    }

    public void Create()
    {
        objText.text = display.text;
        PlayerPrefs.SetString("userName", objText.text);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
