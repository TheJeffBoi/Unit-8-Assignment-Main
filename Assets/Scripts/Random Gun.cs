using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RandomGun : MonoBehaviour
{
    public GameObject gunSpawn;

    public GameObject pistol1;
    public GameObject pistol2;
    public GameObject pistol3; 

    int randPistol = 0;

    private void Start()
    {
        RandomPistol();
        PlacePistol();
    }

    void RandomPistol()
    {
        randPistol = Random.Range(1, 5);
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
}
