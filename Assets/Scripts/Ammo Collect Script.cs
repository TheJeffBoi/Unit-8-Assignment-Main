using TMPro;
using UnityEngine;
using UnityEngine.WSA;

public class AmmoCollectScript : MonoBehaviour
{
    public TextMeshProUGUI totalAmmoText;
    public Animator openBox;

    int totalAmmo;
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
            randAmmo = Random.Range(2, 10);
            totalAmmo = totalAmmo + randAmmo;
            totalAmmoText.text = totalAmmo.ToString();
            activated = true;
        }
    }
}
