using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform playerOrientation;
    [SerializeField] private float movementSpeed;
    
    private Rigidbody playerRigidbody;
    private Vector3 movementDirection;
    private float horizontalInput;
    private float verticalInput;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        GetInput();
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

        playerRigidbody.AddForce(movementDirection.normalized * movementSpeed, ForceMode.Force);
    }
}
