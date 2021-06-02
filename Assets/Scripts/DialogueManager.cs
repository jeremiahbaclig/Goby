using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    private Queue<string> sentences;

    public Animator anim;
    public static bool isTalking = false;

    private void Start()
    {
        sentences = new Queue<string>();
    }

    private void Update()
    {
        GameObject openingTrigger = GameObject.Find("Toggle");
        
        if (openingTrigger.GetComponent<Toggle>().isOn && CutsceneManager.cutscene == 1)
        {
            GameObject.Find("Trigger").GetComponent<DialogueTrigger>().TriggerDialogue();
            openingTrigger.GetComponent<Toggle>().isOn = false;
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        anim.SetBool("IsOpen", true);
        isTalking = true;

        nameText.text = dialogue.name;
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null; // new WaitForSeconds(0.02f); --> issues on consecutive playthrough
        }
    }

    void EndDialogue()
    {
        StopAllCoroutines();
        isTalking = false;
        anim.SetBool("IsOpen", false);
    }
}
