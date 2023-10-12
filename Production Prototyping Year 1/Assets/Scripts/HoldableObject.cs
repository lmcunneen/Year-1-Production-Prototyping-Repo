using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldableObject : MonoBehaviour
{
    [SerializeField] private GameObject cameraHolder;
    
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
            //Find better solution to clipping problem, as it can activate stop holding with more quick turns. Possibly a Line of sight check?
            float objectHoldDistance = Vector3.Distance(holdObjectTransform.position, transform.position);

            if (Input.GetKeyDown(interactKeyReference) || Input.GetKeyDown(KeyCode.Mouse0) || objectHoldDistance >= 1f)
            {
                StopHolding();
            }
        }
    }

    void FixedUpdate()
    {
        if (isHolding)
        {
            HoldObject();
        }
    }

    public void StartHolding(KeyCode interactKey, GameObject interactObjectsHolder)
    {
        interactKeyReference = interactKey;
        interactObjectsHolderReference = interactObjectsHolder;

        objectRigidbody.useGravity = false;

        holdObjectTransform.rotation = transform.rotation;

        cameraHolder.GetComponent<PlayerCamera>().isHoldingReference = true;

        isHolding = true;
    }

    private void HoldObject()
    {
        //Vector3 newPosition = Vector3.Lerp(transform.position, holdObjectTransform.position, heldObjectLerpRate * Time.deltaTime);
        //objectRigidbody.MovePosition(newPosition);

        transform.position = Vector3.Lerp(transform.position, holdObjectTransform.position, heldObjectLerpRate * Time.deltaTime);
        transform.rotation = holdObjectTransform.rotation;

        objectRigidbody.velocity = new Vector3(0, 0, 0);
    }

    private void StopHolding()
    {
        objectRigidbody.useGravity = true;

        cameraHolder.GetComponent<PlayerCamera>().isHoldingReference = false;

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
