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

            StartCoroutine(sceneChange());

            //trigger.SetActive(false);
        }
    }

    IEnumerator sceneChange()
    {
        yield return new WaitForSeconds(transitionDelay);

        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Game");
        playerGunScript.UpdateAmmoCount();

    }
}
