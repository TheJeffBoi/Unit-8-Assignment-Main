using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using UnityEditorInternal;

public class Checkpoints : MonoBehaviour
{
    public GameObject player;
    public GameObject pistolSymbol;
    public Animator transition;
    public GameObject commentBar;
    public TextMeshProUGUI commentText;

    public float beforeTransition;
    public float transitionTime;
    public float afterTranstiton;

    int checkpointCounter;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(pistolSymbol.activeSelf == true)
            {
                CheckpointOne();
            }
            else
            {
                commentBar.SetActive(true);
                commentText.text = "You Must Collect The Pistol Left For You First!";

                print("Before");
                StartCoroutine(Checkpoint(5));
                print("After");
                
                commentText.text = "";
                commentBar.SetActive(true);
            }
        }
    }

    void CheckpointOne()
    {
        StartCoroutine(Checkpoint(0.4f));
        transition.SetBool("Fade In", true);

        StartCoroutine(Checkpoint(1.25f));
        transition.SetBool("Fade In", false);

        transition.SetBool("Fade Out", true);

        player.transform.position = new Vector3(-17.5f, 1, 12.1f);

        StartCoroutine(Checkpoint(1));
        transition.SetBool("Fade Out", false);

        checkpointCounter++;

    }

    IEnumerator Checkpoint(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
    }

}
