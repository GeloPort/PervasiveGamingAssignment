using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public GameObject voiceCapPoint;
    public GameObject keyCapPoint;
    public GameObject playerChar;
    private VoiceCapturePoint voiceCapScript;
    private KeyCapturePoint keyCapScript;
    private UnitAttack attackScript;
    public Image redFlag;
    public Image greenFlag;
    public Image redSword;
    public Image greenSword;

    // Start is called before the first frame update.  Defines both the Components of 
    void Start()
    {
        voiceCapScript = voiceCapPoint.GetComponent<VoiceCapturePoint>();
        keyCapScript = keyCapPoint.GetComponent<KeyCapturePoint>();
        redFlag.enabled = false;
        redSword.enabled = false;
        greenFlag.enabled = false;
        greenSword.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (keyCapScript.isCapturing)
        {
            greenFlag.enabled = true;
        }
        else
        {
            greenFlag.enabled = false;
        }

        if (voiceCapScript.isOnPoint && !voiceCapScript.isCaptured)
        {
            redFlag.enabled = true;
        }
        else
        {
            redFlag.enabled = false;
        }

        if (UnitAttack.voiceEnemyAble)
        {
            redSword.enabled = true;
        }
        else
        {
            redSword.enabled = false;
        }

        if (UnitAttack.keyEnemyAble)
        {
            greenSword.enabled = true;
        }
        else
        {
            greenSword.enabled = false;
        }
    }
}
