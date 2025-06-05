using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavour : MonoBehaviour
{
    public Animator enemyAnim;
    public Transform player;
    public GameObject pistol;
    public GameObject bullet;
    public GameObject flash;
    public Transform attackPoint;
    NavMeshAgent meshAgent;
    public Rigidbody rb;

    public float attackDistance;
    public float chaseDistance = 7.5f;
    public float spread;
    public float shootForce;
    float distance;
    float waitTime = 2;


    // Angular speed in radians per sec.
    public float speed = 1.0f;


    bool playerNear = false;

    void Start()
    {
        meshAgent = GetComponent<NavMeshAgent>();
        enemyAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
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

    public void DoShoot()
    {
        StartCoroutine(ShootCheck());

    }

    IEnumerator ShootCheck()
    {
        meshAgent.destination = transform.position;

        float delay = Random.Range(0.5f, 2);

        yield return new WaitForSeconds(delay);

        if (enemyAnim.GetBool("Shoot") == true)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Vector3 shootSpread = attackPoint.transform.forward;
        shootSpread.x += Random.Range(-0.4f, 0.4f);
        shootSpread.y += Random.Range(-0.4f, 0.4f);

        rb = Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(shootSpread * 32f, ForceMode.Impulse);
        rb.AddForce(transform.up * 8f, ForceMode.Impulse);

        AudioManager.PlaySound(SoundType.EnemyGunshot, 0.5f);

        StartCoroutine(MuzzleFlash());

    }

    IEnumerator MuzzleFlash()
    {
        flash.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        flash.SetActive(false);
    }
}
