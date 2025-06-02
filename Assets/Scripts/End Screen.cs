using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndScreen : MonoBehaviour
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

    public void PlayAgain()
    {
        StartCoroutine(SceneChange());
    }

    IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(1);

        transition.SetTrigger("Start");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Main Scene");

    }

    public void Quit()
    {
        Application.Quit();
    }
}
