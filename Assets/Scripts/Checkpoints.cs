using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using UnityEditorInternal;
using UnityEditor.UI;

public class Checkpoints : MonoBehaviour
{
    public GameObject player;
    public GameObject pistolSymbol;
    public Animator screenTransition;
    public Animator textTransition;
    public GameObject commentBar;
    public TextMeshProUGUI commentText;
    public EnemyHealth enemyHealth;

    public float beforeTransition;
    public float transitionTime;
    public float afterTranstiton;

    Vector3 checkpointTeleport;

    int checkpointCounter;
    int enemyKills = 0;
    int targetKill = 0;

    bool active = false;

    private void Start()
    {
        checkpointTeleport = new Vector3(gameObject.transform.position.x + 2.5f , gameObject.transform.position.y, gameObject.transform.position.z);

        enemyHealth = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealth>();
        enemyKills = enemyHealth.enemysKilled;
    }

    void Update()
    {
        AimKill();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(gameObject.name == "Trigger 1")
            {
                if (pistolSymbol.activeSelf == true && active == false)
                {
                    StartCoroutine(CheckpointOne());
                }
                else
                {
                    StartCoroutine(TextFade());
                }
            }
            else
            {
                /*if (enemyKills = targetKill)
                {
                    StartCoroutine(CheckpointOther());
                }
                else
                {
                    print("Must Kill All Enemys First");
                }*/
            }
        }
    }

    void AimKill()
    {
        if (checkpointCounter == 2)
        {
            targetKill += 1;
        }
        else if (checkpointCounter == 3)
        {
            targetKill += 2;
        }
        else if (checkpointCounter == 4)
        {
            targetKill += 2;
        }
        else if (checkpointCounter == 5)
        {
            targetKill += 3;
        }
        else if (checkpointCounter == 6)
        {
            targetKill += 3;
        }
        else if (checkpointCounter == 7)
        {
            targetKill += 3;
        }
    }

    IEnumerator TextFade()
    {
        active = true;

        commentText.text = "You Must Collect The Pistol That Has Been Left For You First!";

        textTransition.SetBool("Fade In", true);

        yield return new WaitForSeconds(3);

        textTransition.SetBool("Fade In", false);
        textTransition.SetBool("Fade Out", true);

        yield return new WaitForSeconds(1);

        textTransition.SetBool("Fade Out", false);

        active = false;
    }

    IEnumerator CheckpointOne()
    {
        yield return new WaitForSeconds(0.4f);
        screenTransition.SetBool("Fade In", true);

        yield return new WaitForSeconds(1.25f);
        screenTransition.SetBool("Fade In", false);

        screenTransition.SetBool("Fade Out", true);

        player.transform.position = checkpointTeleport;

        yield return new WaitForSeconds(1);
        screenTransition.SetBool("Fade Out", false);

        checkpointCounter++;
        
    }

    IEnumerator CheckpointOther()
    {

        yield return new WaitForSeconds(0.4f);
        screenTransition.SetBool("Fade In", true);

        yield return new WaitForSeconds(1.25f);
        screenTransition.SetBool("Fade In", false);

        screenTransition.SetBool("Fade Out", true);

        player.transform.position = checkpointTeleport;

        yield return new WaitForSeconds(1);
        screenTransition.SetBool("Fade Out", false);

        checkpointCounter++;

    }

}
