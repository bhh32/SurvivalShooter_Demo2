using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDifficulty : MonoBehaviour
{
    [SerializeField] Difficulty newDiff;
    [SerializeField] EnemyHealth[] enemyHealth;
    [SerializeField] GameObject enemyManager;
    EnemyManager[] enemyManagerScripts;

    void Awake()
    {
        //if (newDiff == null) { throw System.ArgumentNullException("DifficultyNull", "Did you remember to put the Difficulty Script into the newDiff variable?"); }
        newDiff = FindObjectOfType<Difficulty>();
        enemyManagerScripts = enemyManager.GetComponents<EnemyManager>();

        if (newDiff._isEasy)
        {
            foreach(EnemyHealth e in enemyHealth)
            {
                e.Health = 75;
            }

            foreach(EnemyManager e in enemyManagerScripts)
            {
                e.spawnTime = 15f;
            }
        }
        else if(newDiff._isHard)
        {
            foreach (EnemyHealth e in enemyHealth)
            {
                e.Armor = 100f;
            }

            foreach(EnemyManager e in enemyManagerScripts)
            {
                e.spawnTime = 2f;
            }
        }
    }
}
