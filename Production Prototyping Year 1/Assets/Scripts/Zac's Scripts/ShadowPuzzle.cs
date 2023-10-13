using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ShadowPuzzle : MonoBehaviour
{
    public GameObject shape1;
    [SerializeField] private Transform rotation;
    public Transform correctRotation;
    public Quaternion correctRotationQuaternion;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cameraHolder;
    [SerializeField] private GameObject crosshair;
    [SerializeField] private GameObject exitText;
    [SerializeField] private Transform shadowCameraPosition;

    private GameObject interactObjectsHolderReference;

    private bool isActive = false;

    void Start()
    {
        rotation = shape1.GetComponent<Transform>();
        correctRotation.rotation = Quaternion.Euler(correctRotationQuaternion.x, correctRotationQuaternion.y, correctRotationQuaternion.z);
        
        Debug.Log(rotation.rotation.y);
        Debug.Log(correctRotation.rotation);
    }
    void Update()
    {
        if (isActive)
        {
            RotateShadow();
        }
        
    }

    public void ActivateShadowPuzzle(GameObject interactObjectsHolder)
    {
        player.GetComponent<ControllerMovement>().enabled = false;

        cameraHolder.GetComponent<FollowTransform>().enabled = false;
        cameraHolder.GetComponent<PlayerCamera>().enabled = false;
        cameraHolder.transform.position = shadowCameraPosition.position;
        cameraHolder.transform.rotation = shadowCameraPosition.rotation;

        crosshair.SetActive(false);
        exitText.SetActive(true);

        interactObjectsHolderReference = interactObjectsHolder;

        StartCoroutine(BeginShadowPuzzle());
    }

    public void RotateShadow()
    {
        Debug.Log("Entered shadowPuzzle");
        if (Input.mouseScrollDelta.y > 0)
        {
            Debug.Log("Rotate right");
        }

        else if (Input.mouseScrollDelta.y < 0)
        {
            Debug.Log("Rotate left");
        }

        if (rotation.rotation.y == correctRotation.rotation.y)
        {
            Debug.Log("Object in correct spot");
        }
    }

    IEnumerator BeginShadowPuzzle()
    {
        yield return new WaitForSeconds(.5f);
        isActive = true;
    }
}
