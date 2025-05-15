using UnityEngine;
using TMPro;
using System.Collections;

public class Comment : MonoBehaviour
{
    public TextMeshProUGUI commentText;
    public Animator textTransition;

    bool active = false;

    void Start()
    {
        if (active == false)
        {
            StartCoroutine(TextFade());
        }
    }

    IEnumerator TextFade()
    {
        yield return new WaitForSeconds(2);

        active = true;

        commentText.text = "Ok, I Left You A Pistol In The Last Carrage Of The Train, Hopefuly It's Sill Empty!";

        textTransition.SetBool("Fade In", true);

        yield return new WaitForSeconds(5);

        textTransition.SetBool("Fade In", false);
        textTransition.SetBool("Fade Out", true);

        yield return new WaitForSeconds(1);

        textTransition.SetBool("Fade Out", false);
    }
}
