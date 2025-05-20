using UnityEngine;

public class BulletScript : MonoBehaviour
{
    EnemyHealth enemyHealthScript;

    void Start()
    {
        enemyHealthScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealth>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemyHealthScript.DamageEnemy();
            //Destroy(gameObject);
            print("Hit Enemy");
        }
        else if (other.tag != "Player" && other.tag != "Ignore")
        {
            print("Hit Other");
            Destroy(gameObject);
        }
    }
}
