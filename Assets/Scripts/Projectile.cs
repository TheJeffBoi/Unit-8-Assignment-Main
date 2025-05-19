using UnityEngine;
using TMPro;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public Camera mainCam;
    public GameObject bullet;
    public GameObject muzzleFlash;
    public TextMeshProUGUI currentAmmoCount;
    public TextMeshProUGUI totalAmmoCount;
    public Transform attackPoint;

    public float shootForce;
    public float upwardsForce;
    public float timeBetweenShooting;
    public float spread;
    public float reloadTime;
    public float timeBeweenShots;

    public int magazineSize;
    public int bulletsPerTap;
    int bulletsLeft;
    int bulletsShot;

    public bool allowButtonHold;
    bool shooting;
    bool readyToShoot;
    bool reloading;

    public bool allowInvoke = true;

    void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    void Update()
    {
        SetAmmoDisplay();
        MyInput();
    }

    void SetAmmoDisplay()
    {
        if(currentAmmoCount != null)
        {
            currentAmmoCount.SetText(bulletsLeft / bulletsPerTap + "");
        }

        if (totalAmmoCount != null)
        {
            totalAmmoCount.SetText(magazineSize / bulletsPerTap + "");
        }
    }

    void MyInput()
    {
        if (allowButtonHold)
        {
            shooting = Input.GetKey(KeyCode.S);
        }
        else
        {
            shooting = Input.GetKeyDown(KeyCode.S);
        }

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading)
        {
            Reload();
        }

        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0)
        {
            Reload();
        }

        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = 0;

            Shoot();
        }
    }

    void Shoot()
    {
        readyToShoot = false;

        Ray ray = mainCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(75);
        }

        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);

        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);

        currentBullet.transform.forward = directionWithSpread.normalized;

        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(mainCam.transform.up * upwardsForce, ForceMode.Impulse);

        if(muzzleFlash != null)
        {
            StartCoroutine(MuzzleFlash());
        }

        bulletsLeft--;
        bulletsShot++;

        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }

        if (bulletsShot < bulletsPerTap && bulletsLeft > 0)
        {
            Invoke("Shoot", timeBeweenShots);
        }
    }

    void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }

    void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false; 
    }

    IEnumerator MuzzleFlash()
    {
        GameObject flash = Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        Destroy(flash);
    }
}
