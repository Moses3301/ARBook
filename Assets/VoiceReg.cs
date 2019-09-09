using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class VoiceReg : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer = null;
    public string[] words;
    int index;
    public GameObject ball;
    public GameObject ballPosContainer;
    Transform[] mballPos;
    Animator anim;
    private void Start()
    {
        Debug.Log("Start() >>");
        index = 0;
        keywordRecognizer = new KeywordRecognizer(words, ConfidenceLevel.Low);
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
        mballPos = ballPosContainer.GetComponentsInChildren<Transform>();
        moveBall();
        anim =  GetComponent<Animator>();
        Debug.Log("Start() <<");
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log(args.text + " ?= " + words[index]);
        if (words[index].Equals(args.text))
        {
            playAnimation();
            if (index < words.Length - 1)
                index++;
            moveBall();
        }
    }

    private void moveBall()
    {
        ball.transform.position = mballPos[index + 1].position;
    }

    private void playAnimation()
    {
        switch (index)
        {
            case 0:
                anim.Play("eggMove");
                break;
            case 9:
                anim.Play("eggPop");
                break;
        }
    }
}

