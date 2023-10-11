using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractObjects : MonoBehaviour
{
    [SerializeField] private Image crosshair;

    [Header("Raycast Properties")]
    [SerializeField] private float objectGrabbingDistance;

    private RaycastHit hitData;
    private bool canInteract = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectInteractableObject();

        if (Input.GetKeyDown(KeyCode.Mouse0) && canInteract)
        {
            InteractWithObject();
        }
    }

    void DetectInteractableObject()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hitData))
        {
            if (hitData.distance <= objectGrabbingDistance)
            {
                if (hitData.collider.gameObject.tag == "IsHoldable")
                {
                    //Debug.Log("Successful Raycast Hit!");
                    crosshair.color = Color.green;

                    canInteract = true;
                }

                else if (hitData.collider.gameObject.tag == "IsTerminal")
                {
                    crosshair.color = Color.blue;

                    canInteract = true;
                }
            }

            else
            {
                //Debug.Log("No Raycast Hit");
                crosshair.color = Color.white;

                canInteract = false;
            }
        }

        else
        {
            crosshair.color = Color.white;

            canInteract = false;
        }
    }

    void InteractWithObject()
    {
        var interactable = hitData.collider.gameObject.GetComponent<Interactable>();

        if (interactable != null)
        {
            if (interactable.enabled == true)
            {
                interactable.InteractSuccess();
            }
        }
    }
}
