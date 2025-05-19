using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
using UnityEngine.InputSystem.iOS;
using static UnityEngine.GraphicsBuffer;

public class EnemyBehavour : MonoBehaviour
{
    public Animator enemyAnim;
    public Transform player;
    public GameObject pistol;
    NavMeshAgent meshAgent;

    public float attackDistance;
    public float chaseDistance = 7.5f;
    float distance;


    // Angular speed in radians per sec.
    public float speed = 1.0f;


    bool playerNear = false;

    void Start()
    {
        meshAgent = GetComponent<NavMeshAgent>();
        enemyAnim = GetComponent<Animator>();
    }

    void Update()
    {
        LookAt();

        StateCheck();

        if (playerNear)
        {
            Chase();
        }
    }

    void LookAt()
    {
        Vector3 targetPostition = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(targetPostition);


    }

    void StateCheck()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= attackDistance)
        {
            enemyAnim.SetBool("Shoot", true);
            Shoot();
        }
        else
        {
            enemyAnim.SetBool("Shoot", false);

        }

        if (Vector3.Distance(transform.position, player.transform.position) <= chaseDistance)
        {
            enemyAnim.SetBool("Player Near", true);
            playerNear = true;
            pistol.SetActive(true);
            Chase();
        }
        else
        {
            enemyAnim.SetBool("Player Near", false);
            playerNear = false;
            pistol.SetActive(false);
        }


    }

    void Chase()
    {
       
        meshAgent.destination = player.transform.position;
    }

    void Shoot()
    {
        meshAgent.destination = transform.position;
    }
}
