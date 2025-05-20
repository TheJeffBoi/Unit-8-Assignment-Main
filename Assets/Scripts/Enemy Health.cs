using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    int enemyHealth = 100;

    void Update()
    {
        print(enemyHealth);
        CheckHealth();
    }

    public void DamageEnemy()
    {
        enemyHealth -= UnityEngine.Random.Range(20, 25);
    }

    void CheckHealth()
    {
        if (enemyHealth < 0)
        {
            Destroy(gameObject);
        }
    }
}
