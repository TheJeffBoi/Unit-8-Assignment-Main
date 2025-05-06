using UnityEngine;
using Unity.Mathematics;
using NUnit.Framework.Interfaces;

public class ArrowPoint : MonoBehaviour
{

    public GameObject door;
    public RectTransform arrow;

    float angle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (arrow != null && door != null && angle > -180 && angle < 180)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(door.transform.position);
            
            
            Vector3 direction = screenPos - arrow.transform.position;

            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            arrow.transform.rotation = Quaternion.Euler(0, 0, -angle);
        }
    }

}
