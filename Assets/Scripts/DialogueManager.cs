using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialogueParent;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Button option1Button;
    [SerializeField] private Button option2Button;

    [SerializeField] private float typingSpeed = 0.05f;

    [SerializeField] private PatienceMeter patienceMeter;

    private int timer = 3;
    private int randomNum;
    public WaitForSeconds waitTime = new WaitForSeconds(1f);

    private List<dialogueString> dialogueList;

    [Header("Player")]

    private int currentDialogueIndex = 0;

    public GameObject dialogueTriggerObject;
    List<dialogueString> list1;
    List<dialogueString> list2;
    List<dialogueString> list3;
    List<dialogueString> list4;
    List<dialogueString> list5;
    List<dialogueString> list6;
    List<dialogueString> list7;
    // Reference to the DialogueManager script
    private DialogueTrigger dialogueTrigger;

    private void Start()
    {
        dialogueParent.SetActive(false);
        dialogueTriggerObject = GameObject.Find("DialogueManager");

        // Get the DialogueManager component from the GameObject
        dialogueTrigger = dialogueTriggerObject.GetComponent<DialogueTrigger>();

        // Now you can access the lists from the DialogueManager
        list1 = dialogueTrigger.dialogueStrings;
        list2 = dialogueTrigger.dialogueStrings2;
        list3 = dialogueTrigger.dialogueStrings3;
        list4 = dialogueTrigger.dialogueStrings4;
        list5 = dialogueTrigger.dialogueStrings5;
        list6 = dialogueTrigger.dialogueStrings6;
        list7 = dialogueTrigger.dialogueStrings7;
    }

    public void DialogueStart(List<dialogueString> textToPrint)
    {
        dialogueParent.SetActive(true);

        currentDialogueIndex = 0;
        dialogueList = textToPrint;

        DisableButtons();

        StartCoroutine(PrintDialogue());
    }

    private void DisableButtons()
    {
        option1Button.interactable = false;
        option2Button.interactable = false;

        option1Button.GetComponentInChildren<TMP_Text>().text = "No Option";
        option2Button.GetComponentInChildren<TMP_Text>().text = "No Option";
    }

    private bool optionSelected = false;

    private IEnumerator PrintDialogue()
    {
        while (currentDialogueIndex < dialogueList.Count)
        {
            dialogueString line = dialogueList[currentDialogueIndex];

            line.startDialogueEvent?.Invoke();
            //AudioManager.instance.Play("Dialog");

            if (line.isQuestion)
            {
                yield return StartCoroutine(TypeText(line.text));

                option1Button.interactable = true;
                option2Button.interactable = true;

                option1Button.GetComponentInChildren<TMP_Text>().text = line.answerOption1;
                option2Button.GetComponentInChildren<TMP_Text>().text = line.answerOption2;

                option1Button.onClick.AddListener(() => HandleOptionSelected(line.option1IndexJump));
                option2Button.onClick.AddListener(() => HandleOptionSelected(line.option2IndexJump));

                yield return new WaitUntil(() => optionSelected);
            }
            else
            {
                yield return StartCoroutine(TypeText(line.text));
            }

            line.startDialogueEvent?.Invoke();
            optionSelected = true;
        }

        DialogueStop();
    }

    private void HandleOptionSelected(int indexJump)
    {
        optionSelected = true;
        DisableButtons();

        // check if the selected option is incorrect
        if (indexJump == -1) // assuming -1 indicates an incorrect option
        {
            patienceMeter.DecreasePatienceByWrongAnswer(); // then you apply penalty to patience meter
        }

        currentDialogueIndex = indexJump;
    }

    private IEnumerator TypeText(string text)
    {
        dialogueText.text = "";

        foreach(char letter in text.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        if(!dialogueList[currentDialogueIndex].isQuestion)
        {
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        }

        if (dialogueList[currentDialogueIndex].isEnd)
        {
            DialogueStop();
        }

        currentDialogueIndex++;
    }

    private void DialogueStop()
    {
        StopAllCoroutines();
        dialogueText.text = "";
        dialogueParent.SetActive(false);

    }

   /* public void ShutUp()
    {
        Debug.Log("Shut Up Pressed");
        DialogueStop();
        patienceMeter.Decreate
        StartCoroutine(Countdown());
        int randomNum = Random.Range(0, 2);
    }*/

    IEnumerator Countdown()
    {
        int randomNum = Random.Range(0, 7);

        while (timer > 0)
        {
            yield return waitTime;
            timer--;
        }


        if (randomNum == 0)
        {
           DialogueStart(list1);
        }

        if(randomNum == 1)
        {
            DialogueStart(list2);
        }

        if (randomNum == 2)
        {
            DialogueStart(list3);
        }

        if (randomNum == 3)
        {
            DialogueStart(list4);
        }

        if (randomNum == 4)
        {
            DialogueStart(list5);
        }

        if (randomNum == 5)
        {
            DialogueStart(list6);
        }

        if (randomNum == 6)
        {
            DialogueStart(list7);
        }


    }
}

