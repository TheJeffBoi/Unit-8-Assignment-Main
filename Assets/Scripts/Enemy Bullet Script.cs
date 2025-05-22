using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Enemy" && other.tag != "Ignore")
        {
            Destroy(gameObject);
        }
    }
}
