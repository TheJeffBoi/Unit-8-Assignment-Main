using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RestartScript : MonoBehaviour
{
    public GameObject screenFade;
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
        screenFade.SetActive(true);

        yield return new WaitForSeconds(1);

        transition.SetTrigger("Start");
        
        yield return new WaitForSeconds(0.5f);
        
        SceneManager.LoadScene("Game");

    }

    public void Quit()
    {
        Application.Quit();
    }
}
