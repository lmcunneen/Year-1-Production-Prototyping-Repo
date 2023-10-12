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

    void Start()
    {
        rotation = shape1.GetComponent<Transform>();
        correctRotation.rotation = Quaternion.Euler(correctRotationQuaternion.x, correctRotationQuaternion.y, correctRotationQuaternion.z);
        
        Debug.Log(rotation.rotation.y);
        Debug.Log(correctRotation.rotation);
    }
    void Update()
    {
        if (rotation.rotation.y == correctRotation.rotation.y)
        {
            Debug.Log("Object in correct spot");
        }
    }

    public void RotationCheck(GameObject interactObjectsHolder)
    {

    }
}
