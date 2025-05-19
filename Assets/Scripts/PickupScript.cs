using UnityEngine;
using TMPro;
using System.Collections;
using System;
using Unity.VisualScripting;

public class PickupScript : MonoBehaviour
{
    GameObject player;
    public GameObject gunSpawn;

    public GameObject pistol1;
    public GameObject pistol2;
    public GameObject pistol3;

    public GameObject defaultHands;
    public GameObject pistolHand1;
    public GameObject pistolHand2;
    public GameObject pistolHand3;

    public Animator actionTextFade;
    public TextMeshProUGUI actionText;
    public TMP_Text promptText;
    public GameObject pistolSymbol;

    bool playerInArea = false;
    bool active = false;

    int randPistol = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        RandomPistol();
        PlacePistol();
    }

    void Update()
    {
        PickUp();
        TextLookAt();
        //print(playerInArea);
    }

    void RandomPistol()
    {
        randPistol = UnityEngine.Random.Range(1, 3);
    }

    void PlacePistol()
    {
        if (randPistol == 1)
        {
            pistol1.transform.position = gunSpawn.transform.position;
        }
        else if (randPistol == 2)
        {
            pistol2.transform.position = gunSpawn.transform.position;
        }
        else if (randPistol == 3)
        {
            pistol3.transform.position = gunSpawn.transform.position;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if( other.gameObject.tag == "Player" && active == false)
        {
            Vector3 selfPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z);
            promptText.transform.position = selfPosition;
            promptText.text = "Pick Up Gun";
            playerInArea = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            promptText.text = "";
            playerInArea = false;
        }
    }

    void TextLookAt()
    {
        promptText.transform.LookAt(player.transform.position);
    }

    void PickUp()
    {
        if (player.GetComponent<PlayerMovement>().pickUpPressed == true)
        {
            if (playerInArea == true && active == false)
            {
                StartCoroutine(Action());
                GunHand();
            }
            else
            {
                player.GetComponent<PlayerMovement>().pickUpPressed = false;
            }
        }
    }


    IEnumerator Action()
    {
        actionTextFade.SetBool("Fade In", true);

        actionText.text = "Picked Up Pistol!";
        promptText.text = "";

        active = true;
        pistolSymbol.SetActive(true);

        DestroyGuns();

        player.GetComponent<PlayerMovement>().pickUpPressed = false;

        yield return new WaitForSeconds(2f);

        actionTextFade.SetBool("Fade In", false);
        actionTextFade.SetBool("Fade Out", true);

        yield return new WaitForSeconds(1f);

        actionTextFade.SetBool("Fade Out", false);
    }

    void GunHand()
    {
        if (randPistol == 1)
        {
            defaultHands.SetActive(false);
            pistolHand1.SetActive(true);
        }
        else if (randPistol == 2)
        {
            defaultHands.SetActive(false);
            pistolHand2.SetActive(true);
        }
        else if (randPistol == 3)
        {
            defaultHands.SetActive(false);
            pistolHand3.SetActive(true);
        }
    }

    void DestroyGuns()
    {
        Destroy(pistol1);
        Destroy(pistol2);
        Destroy(pistol3);
    }
}
