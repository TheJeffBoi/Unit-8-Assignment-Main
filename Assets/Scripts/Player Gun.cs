using TMPro;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public TextMeshProUGUI totalAmmoText;
    public TextMeshProUGUI currentAmmoText;

    int totalAmmo = 0;
    int currentAmmo = 0;
    int fillAmmo = 0;
    
    public int randAmmo = 0;
    public int kills = 0;

    private void Start()
    {
        Reload();
    }

    public void AddAmmo()
    {
        randAmmo = Random.Range(2, 8);
        totalAmmo += randAmmo;
        print("Real" + randAmmo);
        totalAmmoText.text = totalAmmo.ToString();
    }

    public void UpdateAmmoCount()
    {
        print(totalAmmo);
        totalAmmoText.text = totalAmmo.ToString();
    }

    public void Reload()
    {
        fillAmmo = 6 - currentAmmo;
        
        if (totalAmmo - fillAmmo <= 0)
        {
            //print("OutOfAmmo");
        }
        else
        {
            if (fillAmmo !> 0)
            {
                //print("Ammo Full!");
            }
            else
            {
                currentAmmo += fillAmmo;
                currentAmmoText.text = currentAmmo.ToString();

                totalAmmo -= fillAmmo;
                totalAmmoText.text = totalAmmo.ToString();
            }
        }


        if (totalAmmo < 6)
        {
            if (totalAmmo < 0)
            {

            }
            else
            {
                currentAmmo = totalAmmo;
                totalAmmo = 0;
            }
        }
        else
        {
            totalAmmo = totalAmmo - 6;
            currentAmmo = 6;
        }
            currentAmmo = totalAmmo - 6;
        //print (currentAmmo);
    }

    public void AddKill()
    {
        kills++;
    }
}
