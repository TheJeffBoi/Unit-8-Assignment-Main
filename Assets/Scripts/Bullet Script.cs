using UnityEngine;

public class BulletScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" && other.tag != "Ignore")
        {
            Destroy(gameObject);
        }
    }
}
