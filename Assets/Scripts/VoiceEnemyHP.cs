using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceEnemyHP : MonoBehaviour
{
    public float voiceEnemyHP;
    public GameObject voiceEnemyDummy;

    // Start is called before the first frame update
    void Start()
    {
        voiceEnemyHP = 100;
    }

    // Update is called once per frame. It calls the enemyDeath function every frame
    void Update()
    {
        enemyDeath();
    }

    // enemyDeath verifies if the Key Enemy's HP is equal to 0, which deactivates said enemy and calls sets the boolean to
    void enemyDeath()
    {
        if (voiceEnemyHP <= 0)
        {
            voiceEnemyDummy.SetActive(false);
            UnitAttack.voiceEnemyAble = false;
        }
    }
}
