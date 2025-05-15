using UnityEngine;
using TMPro;
using System.Collections;
using System;
using Unity.VisualScripting;

public class PickupScript : MonoBehaviour
{

    GameObject player;
    public Animator actionTextFade;
    public TextMeshProUGUI actionText;
    public TMP_Text promptText;
    public GameObject pistolSymbol;

    bool playerInArea = false;
    bool active = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        PickUp();
        TextLookAt();
    }

    void OnTriggerEnter(Collider other)
    {
        if( other.gameObject.tag == "Player")
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
            if (playerInArea == false && active == false)
            {
                player.GetComponent<PlayerMovement>().pickUpPressed = false;
            }
            else
            {
                StartCoroutine(Action());
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

        player.GetComponent<PlayerMovement>().pickUpPressed = false;

        yield return new WaitForSeconds(2f);

        actionTextFade.SetBool("Fade In", false);
        actionTextFade.SetBool("Fade Out", true);

        yield return new WaitForSeconds(1f);

        actionTextFade.SetBool("Fade Out", false);
    }
}
