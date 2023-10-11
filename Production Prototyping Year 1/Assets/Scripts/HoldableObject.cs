using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldableObject : MonoBehaviour
{
    [Header("Hold Object Parameters")]
    [SerializeField] private Transform holdObjectTransform;
    [SerializeField] private float heldObjectLerpRate;

    private KeyCode interactKeyReference;
    private GameObject interactObjectsHolderReference;

    private Rigidbody objectRigidbody;
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

    public void StartHolding(KeyCode interactKey, GameObject interactObjectsHolder)
    {
        interactKeyReference = interactKey;
        interactObjectsHolderReference = interactObjectsHolder;

        objectRigidbody.useGravity = false;
        isHolding = true;
    }

    private void HoldObject()
    {
        transform.position = Vector3.Lerp(transform.position, holdObjectTransform.position, heldObjectLerpRate * Time.deltaTime);

        //Should also find out how to make relative rotations static also
    }

    private void StopHolding()
    {
        objectRigidbody.useGravity = true;

        StartCoroutine(ReactivateInteractObjects());
        isHolding = false;
    }

    IEnumerator ReactivateInteractObjects()
    {
        //This happens to make the drop input not register as an interaction
        yield return new WaitForEndOfFrame();
        interactObjectsHolderReference.GetComponent<InteractObjects>().DetectionValidator(true);
    }
}
