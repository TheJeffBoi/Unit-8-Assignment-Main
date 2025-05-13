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

        addedAmmo = playerGunScript.randAmmo;
        actionText.text = "+ " + addedAmmo + " Ammo!";

        yield return new WaitForSeconds(5);
    }
}
