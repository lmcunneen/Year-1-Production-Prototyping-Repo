using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldableObject : MonoBehaviour
{
    [SerializeField] private Transform holdObjectPosition;

    private Rigidbody objectRigidbody;
    private KeyCode interactKeyReference;
    private bool isHolding;
    
    void Start()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isHolding)
        {
            HoldObject();

            if (Input.GetKeyDown(interactKeyReference) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                StopHolding();
            }
        }
    }

    public void StartHolding(KeyCode interactKey)
    {
        interactKeyReference = interactKey;

        objectRigidbody.useGravity = false;
        isHolding = true;
    }

    private void HoldObject()
    {
        transform.position = holdObjectPosition.position;
    }

    private void StopHolding()
    {
        Debug.Log("hello?");
        
        objectRigidbody.useGravity = true;

        isHolding = false;
    }
}
