using UnityEngine;
using UnityEngine.UI;

public class BabysitterImageUpdater : MonoBehaviour
{
    public PatienceMeter patienceMeter;
    public Image babysitterImage;
    public Sprite[] babysitterSprites; 
    // Array of sprites for different levels of patience

    void Update()
    {
        if (patienceMeter == null || babysitterImage == null)
        {
            Debug.LogWarning("Patience meter or babysitter image not assigned!");
            return;
        }

        float patienceLevel = patienceMeter.targetProgress / patienceMeter.maxPatience;

        if (patienceLevel <= 0.25f)
        {
            babysitterImage.sprite = babysitterSprites[0]; 
            // Change image to the one representing 0-25% patience
        }
        else if (patienceLevel <= 0.5f)
        {
            babysitterImage.sprite = babysitterSprites[1]; 
            // Change image to the one representing 25-50% patience
        }
        else if (patienceLevel <= 0.75f)
        {
            babysitterImage.sprite = babysitterSprites[2]; 
            // Change image to the one representing 50-75% patience
        }
        else
        {
            babysitterImage.sprite = babysitterSprites[3]; 
            // Change image to the one representing 75-100% patience
        }
    }
}
