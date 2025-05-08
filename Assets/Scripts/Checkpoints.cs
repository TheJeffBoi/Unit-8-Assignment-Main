using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Checkpoints : MonoBehaviour
{
    public GameObject player;
    public Animator transition;

    public float transitionTime;
    public float transitionDelay;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Teleport Player");
            StartCoroutine(sceneChange());
        }
    }

    IEnumerator sceneChange()
    {
        yield return new WaitForSeconds(transitionDelay);

        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        //player.transform.position = new Vector3(17.5f, 1, 12.1f);

    }

}
