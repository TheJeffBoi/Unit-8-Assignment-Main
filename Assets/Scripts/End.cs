using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class End : MonoBehaviour
{
    public Animator transition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(SceneChange());
        }
    }

    IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(0.5f);

        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("End");

    }


}
