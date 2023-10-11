using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform playerOrientation;
    [SerializeField] private float mouseSensitivity;

    private Vector2 turn;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        turn.x += Input.GetAxisRaw("Mouse X") * mouseSensitivity;
        turn.y += Input.GetAxisRaw("Mouse Y") * mouseSensitivity;

        turn.y = Mathf.Clamp(turn.y, -90f, 90f);

        transform.rotation = Quaternion.Euler(-turn.y, turn.x, 0);
        playerOrientation.rotation = Quaternion.Euler(0, turn.x, 0);
    }
}
