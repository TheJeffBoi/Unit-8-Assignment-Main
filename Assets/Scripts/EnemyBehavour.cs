using UnityEngine;

public class EnemyBehavour : MonoBehaviour
{
    public GameObject pistol;
    public Animator enemyAnim;

    bool playerNear = false;

    void OnTriggerEnter(Collider other)
    {
        enemyAnim.SetBool("Player Near", true);
        playerNear = true;
        pistol.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        enemyAnim.SetBool("Player Near", false);
        playerNear = false;
        pistol.SetActive(false);
    }
}
