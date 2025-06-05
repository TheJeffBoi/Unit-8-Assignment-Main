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
        AudioManager.PlaySound(SoundType.StationAmbiance, 0.5f);
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

        AudioManager.PlaySound(SoundType.DoorOpen, 1.25f);
        AudioManager.StopSound(SoundType.StationAmbiance);

        SceneManager.LoadScene("Game");
        playerGunScript.UpdateAmmoCount();

    }
}
