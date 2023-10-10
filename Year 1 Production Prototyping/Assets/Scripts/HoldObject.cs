using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoldObject : MonoBehaviour
{
    [SerializeField] private Image crosshair;

    [Header("Raycast Properties")]
    [SerializeField] private float objectGrabbingDistance;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectHoldableObject();
    }

    void DetectHoldableObject()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitData))
        {
            if (hitData.distance <= objectGrabbingDistance && hitData.collider.gameObject.tag == "IsHoldable")
            {
                //Debug.Log("Successful Raycast Hit!");
                crosshair.color = Color.green;
            }

            else
            {
                //Debug.Log("No Raycast Hit");
                crosshair.color = Color.white;
            }
        }
    }
}
