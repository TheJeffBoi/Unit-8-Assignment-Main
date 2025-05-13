using NUnit.Framework;
using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.WSA;

public class AmmoCollectScript : MonoBehaviour
{
    PlayerGun playerGunScript;

    public TextMeshProUGUI totalAmmoText;
    public TextMeshProUGUI actionText;
    public Animator openBox;
    public Animator actionTextFade;

    int totalAmmo = 0;
    int addedAmmo;
    int randAmmo;
    bool activated = false;

    void Start()
    {
        openBox = GetComponent<Animator>();
        playerGunScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGun>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && activated == false)
        {
            StartCoroutine(Action());
        }
    }

    IEnumerator Action()
    {
        activated = true;

        openBox.SetBool("Open", true);
        playerGunScript.AddAmmo();

        actionTextFade.SetBool("Fade In", true);

        addedAmmo = playerGunScript.randAmmo;
        actionText.text = "+ " + addedAmmo + " Ammo!";

        yield return new WaitForSeconds(2);

        actionTextFade.SetBool("Fade In", false);
        actionTextFade.SetBool("Fade Out", true);

        yield return new WaitForSeconds(1);

        actionTextFade.SetBool("Fade Out", false);
    }
}
