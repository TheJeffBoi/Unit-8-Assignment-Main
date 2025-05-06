using UnityEngine;
using TMPro;

public class PickupScript : MonoBehaviour
{

    GameObject player;
    public TMP_Text promptText;

    bool playerInArea = false;

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
            if (playerInArea == false)
            {
                player.GetComponent<PlayerMovement>().pickUpPressed = false;
            }
            else
            {
                Destroy(gameObject);
                promptText.text = "";
                player.GetComponent<PlayerMovement>().pickUpPressed = false;
            }
        }
    }
}
