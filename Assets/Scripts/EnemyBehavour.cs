using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.iOS;

public class EnemyBehavour : MonoBehaviour
{
    public Animator enemyAnim;
    public Transform player;
    public GameObject pistol;
    NavMeshAgent meshAgent;

    public float attackDistance;
    public float chaseDistance = 7.5f;
    float distance;


    bool playerNear = false;

    void Start()
    {
        meshAgent = GetComponent<NavMeshAgent>();
        enemyAnim = GetComponent<Animator>();
    }

    void Update()
    {
        //Distance();
        StateCheck();
        if (playerNear)
        {
            Chase();
        }
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
            Chase();
        }
        else
        {
            enemyAnim.SetBool("Player Near", false);
            playerNear = false;
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

    void Distance()
    {
        distance = Vector3.Distance(meshAgent.transform.position, player.position);

        if (distance < attackDistance && playerNear == true)
        {
            print("stop");
            meshAgent.isStopped = true;
            enemyAnim.SetBool("Shoot", true);            
        }
        else
        {
            print("unstop");
            meshAgent.isStopped = false;
            enemyAnim.SetBool("Shoot", false);
            meshAgent.destination = player.position;
            //print(meshAgent.destination);
        }
    }

    /*void OnAnimatorMove()
    {
        if (enemyAnim.GetBool("Shoot") == false)
        {

            meshAgent.speed = (enemyAnim.deltaPosition / Time.deltaTime).magnitude;
        }
    } 

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enemyAnim.SetBool("Player Near", true);
            playerNear = true;
            pistol.SetActive(true);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enemyAnim.SetBool("Player Near", false);
            playerNear = false;
            pistol.SetActive(false);
        }
    }

    */
}
