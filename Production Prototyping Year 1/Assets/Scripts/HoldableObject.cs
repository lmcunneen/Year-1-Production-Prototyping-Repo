using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldableObject : MonoBehaviour
{
    [SerializeField] private GameObject cameraHolder;
    
    [Header("Hold Object Parameters")]
    [SerializeField] private Transform holdObjectTransform;
    [SerializeField] private float heldObjectLerpRate;

    [Header("Raycast Parameters")]
    [SerializeField] private Transform playerCapsule;
    [SerializeField] private LayerMask holdObjectRaycastLayerMask;
    [SerializeField] private LayerMask playerRaycastLayerMask;

    private KeyCode interactKeyReference;
    private GameObject interactObjectsHolderReference;

    private Rigidbody objectRigidbody;
    private bool isHolding;
    private float objectHoldDistance;

    void Start()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isHolding)
        {
            // The LOSValidator will also do a raycast to the player capsule, but will need to be troubleshooted in order to work
            if (LOSValidator(holdObjectTransform, holdObjectRaycastLayerMask))
            {
                objectHoldDistance = 0f;
            }

            else
            {
                objectHoldDistance = Vector3.Distance(holdObjectTransform.position, transform.position);
            }

            if (Input.GetKeyDown(interactKeyReference) || Input.GetKeyDown(KeyCode.Mouse0) || objectHoldDistance >= 0.75f)
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

    private bool LOSValidator(Transform raycastTransform, LayerMask raycastLayerMask)
    {   
        Vector2 raycastDirection = (raycastTransform.position - transform.position).normalized;

        Physics.Raycast(transform.position, raycastDirection, out RaycastHit LOSData, 999f, raycastLayerMask, QueryTriggerInteraction.Ignore);
        Debug.DrawRay(transform.position, raycastDirection, Color.white);

        if (LOSData.collider != null)
        {
            Debug.DrawLine(transform.position, LOSData.point, Color.red);

            Debug.Log(LOSData.collider.gameObject.name);

            return false;
        }

        return true;
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
