using TMPro;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public TextMeshProUGUI totalAmmoText;

    int totalAmmo = 0;
    int randAmmo;

    public void UpdateAmmoCount()
    {
        randAmmo = Random.Range(2, 8);
        totalAmmo += randAmmo;
        totalAmmoText.text = totalAmmo.ToString();
    }
}
