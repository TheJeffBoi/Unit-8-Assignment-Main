using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.WSA;

public class AmmoCollectScript : MonoBehaviour
{
    PlayerGun playerGunScript;

    public TextMeshProUGUI totalAmmoText;
    public Animator openBox;

    int totalAmmo = 0;
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
            openBox.SetBool("Open", true);
            activated = true;
            playerGunScript.AddAmmo();
        }
    }
}
