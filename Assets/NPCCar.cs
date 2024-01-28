using UnityEngine;

public class NPCCar : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit an NPC car!");

            PatienceMeter patienceMeter = other.GetComponent<PatienceMeter>();
            if (patienceMeter != null)
            {
                patienceMeter.DecreasePatienceByHit();
            }
        }
    }
}
