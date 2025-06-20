using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{

    public PlayerGun playerGunScript;

    public GameObject enemy;
    public Animator enemyAnim;
    Rigidbody rb;

    public int enemysKilled;
    public int enemyTotalHealth;
    public int enemyHealth;

    private void Start()
    {
        playerGunScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGun>();

        enemy.GetComponent<CapsuleCollider>();
        enemy.GetComponent<EnemyBehavour>();
        enemy.GetComponent<NavMeshAgent>();

        rb = GetComponent<Rigidbody>();

        enemyTotalHealth = enemyHealth;
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
        //print("Enemy Health" + enemyHealth);
    }

    void CheckHealth()
    {
        if (enemyHealth < 0)
        {
            enemyAnim.SetTrigger("Death");
            
            rb.constraints = RigidbodyConstraints.FreezeRotationY;
            enemy.GetComponent<NavMeshAgent>().enabled = false;
            enemy.GetComponent<CapsuleCollider>().enabled = false;
            enemy.GetComponent<EnemyBehavour>().enabled = false;

            playerGunScript.AddKill();
        }
    }
}