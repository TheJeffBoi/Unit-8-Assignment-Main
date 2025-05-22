using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public GameObject enemy;
    public Animator enemyAnim;

    public int enemysKilled;
    int enemyHealth = 100;

    void Update()
    {
        print(enemyHealth);
        CheckHealth();
    }

    public void DamageEnemy()
    {
        enemyHealth -= 20;
    }

    void CheckHealth()
    {
        if (enemyHealth < 0)
        {
            print("Enemy Health Less Than 0");

            enemyAnim.SetBool("Death", true);

            //GetComponent<Rigidbody>().enabled = false;
            enemy.GetComponent<CapsuleCollider>().enabled = false;
            enemy.GetComponent<EnemyBehavour>().enabled = false;
            enemy.GetComponent<NavMeshAgent>().enabled = false;

            enemysKilled++;
        }
    }
}
