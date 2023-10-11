using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform playerOrientation;
    [SerializeField] private float movementSpeedBase;
    [SerializeField] private KeyCode crouchKey;
    
    private Rigidbody playerRigidbody;
    private Vector3 movementDirection;
    private Vector3 playerScaleBase;
    private Vector3 playerScaleCrouching;
    private float movementSpeedCalc;
    private float horizontalInput;
    private float verticalInput;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();

        playerScaleBase = transform.localScale;
        playerScaleCrouching = new Vector3(transform.localScale.x, transform.localScale.y * 0.5f, transform.localScale.z);
    }

    void Update()
    {
        GetInput();

        if (Input.GetKey(crouchKey))
        {
            transform.localScale = playerScaleCrouching;
            movementSpeedCalc = movementSpeedBase * 0.6f;
        }

        else
        {
            transform.localScale = playerScaleBase;
            movementSpeedCalc = movementSpeedBase;
        }
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void GetInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    void MovePlayer()
    {
        movementDirection = playerOrientation.forward * verticalInput + playerOrientation.right * horizontalInput;

        playerRigidbody.AddForce(movementDirection.normalized * movementSpeedCalc, ForceMode.Force);
    }
}
