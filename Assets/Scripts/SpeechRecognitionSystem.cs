using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechRecognitionSystem : MonoBehaviour
{
    public bool doCap = false;
    public bool doAttack = false;
    private KeywordRecognizer kRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    public GameObject capPoint;
    private VoiceCapturePoint capScript;

    private void Start()
    {
        capScript = capPoint.GetComponent<VoiceCapturePoint>();

        actions.Add("attack", saidAttack);
        actions.Add("capture", saidCap);

        kRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        kRecognizer.OnPhraseRecognized += RecognizedSpeech;
        kRecognizer.Start();
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void saidAttack()
    {
        Debug.Log("The action has been done");
        doAttack = true;
    }

    public void saidCap()
    {
        if (capScript.isOnPoint && !capScript.isCaptured)
        {
            StartCoroutine(capScript.Points());
        }
        else
        {
            Debug.Log("The action can't be done");
        }
    }
}
