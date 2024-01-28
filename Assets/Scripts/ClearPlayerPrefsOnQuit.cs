using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPlayerPrefsOnQuit : MonoBehaviour
{
    private void OnApplicationQuit()
    {
        // clear all stored names from PlayerPrefs
        PlayerPrefs.DeleteAll();
    }
}
