using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public TMP_Text NameText;
    public TMP_Text SentenceText;

    public GameObject UI;
    private Queue<string> sentences;

    void Start(){

        sentences = new Queue<string>();
    }

    public void StartDialog(Dialog dialog){

        UI.SetActive(true);
        

        print("Start conv" + dialog.name);
        NameText.text = dialog.name;

        sentences.Clear();

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence(){

        if(sentences.Count == 0){
            
            EndDialog();
            return;
        }

        string sentence = sentences.Dequeue();
        SentenceText.text = sentence;
    }

    void EndDialog(){
        UI.SetActive(false);
        print("End dialog");
    }
}
