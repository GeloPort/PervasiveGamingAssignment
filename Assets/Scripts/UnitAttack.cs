using UnityEngine;

public class UnitAttack : MonoBehaviour
{
    public static bool voiceEnemyAble = false;
    public static bool keyEnemyAble = false;
    public VoiceEnemyHP voiceEnemyDummy;
    public KeyEnemyHP keyEnemyDummy;
    public SpeechRecognitionSystem speechSystem;
    public UIScript UISystem;

    //OnTriggerEnter to check when Enemy enters AttackArea, checking that it's possible to attack it by verifying the target's tag. If the tag is equal to "Enemy", it is defined as a Voice Enemy, if it is equal to "Key Enemy" it is defined as a KeyEnemy
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Debug.Log("Voice Enemy is in attacking range");
            voiceEnemyAble = true;

        }
        
        if(other.tag == "KeyEnemy")
        {
            Debug.Log("Key Enemy is in attacking range");
            keyEnemyAble = true;
        }
    }


    //OnTriggerEnter to check when Enemy leaves AttackArea, unchecking that it's possible to attack it, once the tagged target leaves the collider
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("Voice Enemy is no longer in attacking range");
            voiceEnemyAble = false;

        }

        if (other.tag == "KeyEnemy")
        {
            Debug.Log("Key Enemy is no longer in attacking range");
            keyEnemyAble = false;
        }
    }

    // Start is called before the first frame update. Sets the Speech Recognition System as speechSystem to be invoked by functions
    private void Start()
    {
        speechSystem = GetComponent<SpeechRecognitionSystem>();
    }

    // Update is called once per frame. Calls for all attack functions every frame
    private void Update()
    {
        playerVoiceAttack();
        playerKeyAttack();
        playerKeyMiss();
        playerVoiceMiss();
    }


    //playerKeyAttack checks if the enemy in range is a Key Enemy and if the order to attack has been given by saying "Attack" and doing damage to the tagged enemy
    void playerVoiceAttack()
    {
        if (voiceEnemyAble == true && speechSystem.doAttack == true)
        {
            Debug.Log("Player has attacked the Voice Enemy");
            voiceEnemyDummy.voiceEnemyHP -= 100f;
            speechSystem.doAttack = false;
        }
    }
    
    //playerVoiceMiss checks for when the player orders to attack by saying "Attack" when the enemy is out of range
    void playerVoiceMiss()
    {
        if (voiceEnemyAble == false && speechSystem.doAttack == true)
        {
            Debug.Log("Player voice has missed the attack");
            speechSystem.doAttack = false;
        }
    }

    //playerKeyAttack checks if the enemy in range is a Key Enemy and if the order to attack has been given by pressing "X"
    void playerKeyAttack()
    {
        if (keyEnemyAble == true && Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Player has attacked the Key Enemy");
            keyEnemyDummy.keyEnemyHP -= 100f;
        }
    }

    //playerKeyMiss checks for when the player orders to attack by pressing "X" when the enemy is out of range
    void playerKeyMiss()
    {
        if (keyEnemyAble == false && Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Player key has missed the attack");
        }
    }
}
