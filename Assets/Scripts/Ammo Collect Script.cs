using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.WSA;

public class AmmoCollectScript : MonoBehaviour
{
    public TextMeshProUGUI totalAmmoText;
    public Animator openBox;

    int totalAmmo = 0;
    int randAmmo;
    bool activated = false;

    void Start()
    {
        openBox = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && activated == false)
        {
            openBox.SetBool("Open", true);
            randAmmo = Random.Range(2, 8);
            Debug.Log("You got" + randAmmo);
            totalAmmo += randAmmo;
            Debug.Log(totalAmmo);
            totalAmmoText.text = totalAmmo.ToString();
            activated = true;
        }
    }
}
