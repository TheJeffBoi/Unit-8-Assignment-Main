using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;


public class PlayerMovement : MonoBehaviour
{

    PlayerControls controls;

    PlayerGun playerGunScript;

    public GameObject pistolSymbol;
    public TextMeshProUGUI currentAmmoText;
    public TextMeshProUGUI totalAmmoText;

    public Camera mainCamera;
    public Rigidbody rb;

    //Vector
    Vector2 move;
    Vector2 rotate;

    //Bools
    public bool pickUpPressed;
    bool sprint = false;
    bool mouseLocked;

    //Floats
    public float speed;
    float currentFov;
    float targetFov;
    float xRotation;
    float yRotation;
    public float minLook;
    public float maxLook;

    private void Awake()
    {
        controls = new PlayerControls();

        //Read Joystick Movement For Walk
        controls.Movement.Walk.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Movement.Walk.canceled += ctx => move = Vector2.zero;

        //Read Joystick Movement For Rotate
        controls.Movement.Rotation.performed += ctx => rotate = ctx.ReadValue<Vector2>();
        controls.Movement.Rotation.canceled += ctx => rotate = Vector2.zero;

        //Read Joystick Press For Sprint
        controls.Movement.Sprint.performed += ctx => Sprint();
        controls.Movement.PickUp.performed += ctx => PickUp();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        playerGunScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGun>();

        //Setting Variables
        targetFov = 60f;
        currentFov = targetFov;
    }

    void Update()
    {
        Walk();
        Look();
        CursorLock();
        UpdateFov();
        Reload();
    }

    void OnEnable()
    {
        controls.Movement.Enable();
    }

    void OnDisable()
    {
        controls.Movement.Disable();
    }
    void Walk()
    {
        rb.linearVelocity = (move.y * speed * transform.forward) + (move.x * speed * transform.right);
    }
    void Look()
    {
        yRotation += -rotate.y;

        if (yRotation < -10)
        {
            yRotation = -10;
        }
        if (yRotation > 8)
        {
            yRotation = 8;
        }

        xRotation += rotate.x;

        mainCamera.transform.rotation = Quaternion.Euler(yRotation, xRotation, 0);
        transform.rotation = Quaternion.Euler(0, xRotation, 0);
    }

    void Sprint()
    {
        if (sprint == false)
        {
            speed = speed * 1.5f;
            targetFov = 65;
            sprint = true;
        }
        else if (sprint == true)
        {
            speed = speed / 1.5f;
            targetFov = 60;

            sprint = false;
        }
    }

    void CursorLock()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1) == true)
        {
            if(mouseLocked == false)
            {
                mouseLocked = true;
                Cursor.visible = false;
                //Cursor.lockState = CursorLockMode.Locked;
            }
            else if(mouseLocked == true)
            {
                mouseLocked = false;
                Cursor.visible = true;
                //Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    void PickUp()
    {
        pickUpPressed = true;
    }

    void UpdateFov()
    {
        currentFov = Mathf.Lerp(currentFov, targetFov, 10 * Time.deltaTime);

        // Update The Camera's FOV
        Camera.main.fieldOfView = currentFov;

    }

    void Reload()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            if (pistolSymbol.activeSelf == true)
            {
                playerGunScript.Reload();
            }
        }
    }

}