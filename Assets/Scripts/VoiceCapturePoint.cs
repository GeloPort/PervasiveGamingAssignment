using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceCapturePoint : MonoBehaviour
{
    public float points = 0;
    public GameObject playerChar;
    private SpeechRecognitionSystem speechSystem;
    public bool isOnPoint = false;
    public bool isCaptured = false;
    private Material vCapMaterial;
    public Color voiceCapColour;

    //
    private void Start()
    {
        speechSystem = playerChar.GetComponent<SpeechRecognitionSystem>();
        vCapMaterial = gameObject.GetComponent<Renderer>().material;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player has entered");
        }

        isOnPoint = true;
    }
    
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Player has exitted");
        StopCoroutine("Counter");
        isOnPoint = false;
    }

    public IEnumerator Points() {
        yield return Counter();
        Debug.Log("The Point Has Been Captured");
    }

    IEnumerator Counter()
    {
        Vector3 originalposition = gameObject.transform.position;
        Vector3 originalscale = gameObject.transform.localScale;
        Vector3 destinationscale = new Vector3(15f, 3f, 10f);
        Vector3 destinationposition = new Vector3(15f, 1.5f, 15f);

        bool Count = true;
        while (Count)
        {
            points++;
            Debug.Log(points + " Voice points");
            yield return new WaitForSeconds(0.1f);
            gameObject.transform.localScale = Vector3.Lerp(originalscale, destinationscale, points / 100);
            gameObject.transform.position = Vector3.Lerp(originalposition, destinationposition, points / 100);
            if (points == 100)
            {
                Count = false;
                speechSystem.doCap = false;
                isCaptured = true;
                vCapMaterial.color = voiceCapColour;
            }
        }
    }
}
