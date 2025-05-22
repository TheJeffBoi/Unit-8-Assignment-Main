using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public PlayerGun playerGunScript;

    public GameObject enemy;
    public Animator enemyAnim;

    public int enemysKilled;
    int enemyHealth = 100;

    private void Start()
    {
        playerGunScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGun>();

        enemy.GetComponent<CapsuleCollider>();
        enemy.GetComponent<EnemyBehavour>();
        enemy.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        CheckHealth();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player Bullet")
        {
            DamageEnemy();
        }
    }

    void DamageEnemy()
    {
        enemyHealth -= 20;
    }

    void CheckHealth()
    {
        if (enemyHealth < 0)
        {
            enemyAnim.SetTrigger("Death");

            enemy.GetComponent<CapsuleCollider>().enabled = false;
            enemy.GetComponent<EnemyBehavour>().enabled = false;
            enemy.GetComponent<NavMeshAgent>().enabled = false;

            playerGunScript.AddKill();
        }
    }
}
