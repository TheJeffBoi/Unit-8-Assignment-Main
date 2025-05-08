using TMPro;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public TextMeshProUGUI totalAmmoText;
    //public TextMeshProUGUI totalAmmoTextGame;

    int totalAmmo = 0;
    int randAmmo;

    public void AddAmmo()
    {
        randAmmo = Random.Range(2, 8);
        totalAmmo += randAmmo;
        totalAmmoText.text = totalAmmo.ToString();
    }

    public void UpdateAmmoCount()
    {
        print("Before Ammo Update");
        print(totalAmmo);
        totalAmmoText.text = totalAmmo.ToString();
        print("After Ammo Update");
    }
}
