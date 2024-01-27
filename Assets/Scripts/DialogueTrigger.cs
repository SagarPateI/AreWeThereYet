using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{

    public WaitForSeconds waitTime = new WaitForSeconds(1f);
    private int timer = 3;
    [SerializeField] private List<dialogueString> dialogueStrings = new List<dialogueString>();

    void Start()
    {
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        while (timer > 0)
        {
            yield return waitTime;
            timer--;
        }

        gameObject.GetComponent<DialogueManager>().DialogueStart(dialogueStrings);


    }
}


[System.Serializable]

public class dialogueString
{
    public string text; //Represent child question text.
    public bool isEnd; //Represent if the line is the final line for the dialogue tree

    [Header("Branch")]
    public bool isQuestion;
    public string answerOption1;
    public string answerOption2;
    public int option1IndexJump;
    public int option2IndexJump;

    [Header("Triggered Events")]
    public UnityEvent startDialogueEvent;
    public UnityEvent endDialogueEvent;
}


