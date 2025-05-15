using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using UnityEditorInternal;

public class Checkpoints : MonoBehaviour
{
    public GameObject player;
    public GameObject pistolSymbol;
    public Animator screenTransition;
    public Animator textTransition;
    public GameObject commentBar;
    public TextMeshProUGUI commentText;

    public float beforeTransition;
    public float transitionTime;
    public float afterTranstiton;

    int checkpointCounter;

    bool active = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(pistolSymbol.activeSelf == true && active == false)
            {
                StartCoroutine(CheckpointOne());
            }
            else
            {
                StartCoroutine(TextFade());
            }
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

        player.transform.position = new Vector3(-17.5f, 1, 12.1f);

        yield return new WaitForSeconds(1);
        screenTransition.SetBool("Fade Out", false);

        checkpointCounter++;
        
    }

}
