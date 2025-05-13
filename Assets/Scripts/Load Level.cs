using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadLevel : MonoBehaviour
{
    PlayerGun playerGunScript;

    public Animator transition;
    public GameObject trigger;
    public TextMeshProUGUI objectiveText;
    public TextMeshProUGUI objectiveTextBackground;

    public float transitionTime;
    public float transitionDelay;

    void Start()
    {
        playerGunScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGun>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            objectiveText.fontStyle ^= FontStyles.Strikethrough;
            objectiveText.color = Color.gray;

            objectiveTextBackground.fontStyle ^= FontStyles.Strikethrough;
            objectiveTextBackground.color = Color.white;

            LoadGame();

            //trigger.SetActive(false);
        }
    }

    void LoadGame()
    {
        StartCoroutine(Checkpoint(0.4f));
        transition.SetBool("Fade In", true);

        StartCoroutine(Checkpoint(1.25f));
        transition.SetBool("Fade In", false);

        transition.SetBool("Fade Out", true);

        SceneManager.LoadScene("Game");

        StartCoroutine(Checkpoint(1));
        transition.SetBool("Fade Out", false);

        playerGunScript.UpdateAmmoCount();
    }

    IEnumerator Checkpoint(float delayTime)
    {
        print("Delay");
        yield return new WaitForSeconds(delayTime);
    }
}
