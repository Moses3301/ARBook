using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class VoiceReg : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer = null;
    string[] words = { "we", "only", "said", "goodbye", "with", "words",
                        "I", "died", "a hundred", "times",
                        "You", "go", "back", "to", "her",
                        "And", "I", "go", "back", "to",
                        "I", "go", "back", "to", "us" };
    int index;
    TextMesh mText;
    GameObject mball;
    Transform[] mballPos;
    private void Start()
    {
        Debug.Log("Start() >>");
        index = 0;
        mText = GameObject.Find("Text").GetComponent<TextMesh>();
        mball = GameObject.Find("ball");
        mballPos = GameObject.Find("ballPos").GetComponentsInChildren<Transform>();
        keywordRecognizer = new KeywordRecognizer(words, ConfidenceLevel.Low);
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
        moveBall();
        Debug.Log("Start() <<");
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log(args.text);
        if (words[index].Equals(args.text))
        {
            updateHelpText();
            if (index < words.Length - 1)
                index++;
            moveBall();
        }
    }

    private void moveBall()
    {
        Debug.Log("ball move to " + mballPos[index + 1]);
        mball.transform.position = mballPos[index + 1].position;
    }
    private void updateHelpText()
    {
        mText.text = words[index];
    }
}
