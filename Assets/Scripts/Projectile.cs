using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using System.Collections;

public class Projectile : MonoBehaviour
{
    PlayerControls controls;

    PickupScript pickupScript;

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
    bool hasGun = false;

    public bool allowInvoke = true;

    void Awake()
    {

        controls = new PlayerControls();

        controls.Movement.Shoot.performed += ctx => ShootCheck();
        controls.Movement.Reload.performed += ctx => ReloadCheck();

        bulletsLeft = magazineSize;
        readyToShoot = true;

    }

    void Start()
    {
        pickupScript = GameObject.FindGameObjectWithTag("Gun").GetComponent<PickupScript>();
    }

    void Update()
    {
        SetAmmoDisplay();
        MyInput();
    }

        void OnEnable()
    {
        controls.Movement.Enable();
    }

    void OnDisable()
    {
        controls.Movement.Disable();
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
        if (readyToShoot && !reloading && bulletsLeft <= 0)
        {
            Reload();
        }
    }

    void ShootCheck()
    {
        if (readyToShoot && !reloading && bulletsLeft > 0 && pickupScript.active == true)
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

    void ReloadCheck()
    {
        if (bulletsLeft < magazineSize && !reloading && pickupScript.active == true)
        {
            Reload();
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
