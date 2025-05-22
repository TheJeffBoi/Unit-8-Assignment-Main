using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class Checkpoints : MonoBehaviour
{
    public GameObject player;
    public GameObject pistolSymbol;
    public Animator screenTransition;
    public Animator textTransition;
    public GameObject commentBar;
    public TextMeshProUGUI commentText;
    public PlayerGun enemyKillScript;

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
        enemyKillScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGun>();
        enemyKills = enemyKillScript.kills;
    }

    private void Update()
    {
        print(checkpointCounter);
        

        print(targetKill);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {

            if(gameObject.name == "Trigger 1")
            {
                AimKill();

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
                AimKill();

                if (enemyKills == targetKill)
                {
                    print(enemyKills);
                    print(targetKill);
                    StartCoroutine(CheckpointOther());
                }
                else
                {
                    print("Must Kill All Enemys First");
                }
            }
        }
    }

    void AimKill()
    {
        if (checkpointCounter == 1)
        {
            targetKill += 1;
        }
        else if (checkpointCounter == 2)
        {
            targetKill += 2;
        }
        else if (checkpointCounter == 3)
        {
            targetKill += 2;
        }
        else if (checkpointCounter == 4)
        {
            targetKill += 3;
        }
        else if (checkpointCounter == 5)
        {
            targetKill += 3;
        }
        else if (checkpointCounter == 6)
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

        yield return new WaitForSeconds(3);
    }

    public void AddKill()
    {
        enemyKills++;
    }

}
