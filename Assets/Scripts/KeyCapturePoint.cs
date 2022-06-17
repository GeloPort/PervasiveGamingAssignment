using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCapturePoint : MonoBehaviour
{
    public float points = 0;
    public GameObject playerChar;
    public bool isOnPoint = false;
    public bool isCaptured = false;
    public bool isCapturing = false;
    private Material kCapMaterial;
    public Color keyCapColour;


    private void Start()
    {
        kCapMaterial = gameObject.GetComponent<Renderer>().material;
    }

    private void Update()
    {
        if (isCapturing && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine("Points");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isOnPoint = true;

            if(!isCaptured)
            {
                Debug.Log("Player has entered");
                isCapturing = true;
            }
        }
        else
        {
            isCapturing = false;
            isOnPoint = false;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Player has exitted");
        StopCoroutine("Counter");
        isOnPoint = false;
        isCapturing = false;
    }

    public IEnumerator Points() {
        yield return Counter();
        Debug.Log("The Key Point Has Being Captured");
    }

    IEnumerator Counter()
    {
        Vector3 originalposition = gameObject.transform.position;
        Vector3 originalscale = gameObject.transform.localScale;
        Vector3 destinationscale = new Vector3(15f, 3f, 10f);
        Vector3 destinationposition = new Vector3(15f, 1.5f, -15f);

        bool Count = true;
        while (Count)
        {
            points++;
            Debug.Log(points + " Key points");
            yield return new WaitForSeconds(0.1f);
            gameObject.transform.localScale = Vector3.Lerp(originalscale, destinationscale, points / 100);
            gameObject.transform.position = Vector3.Lerp(originalposition, destinationposition, points / 100);
            if (points == 100)
            {
                Count = false;
                isCaptured = true;
                isOnPoint = false;
                isCapturing = false;
                kCapMaterial.color = keyCapColour;
            }
        }
    }
}
