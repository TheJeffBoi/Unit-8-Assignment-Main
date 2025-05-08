using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Teleport Player");
        }
    }
}
