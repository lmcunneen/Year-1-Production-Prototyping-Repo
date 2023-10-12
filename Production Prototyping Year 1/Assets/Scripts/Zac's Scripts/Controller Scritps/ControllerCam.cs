using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ControllerCam : MonoBehaviour
{
    [SerializeField] private Transform playerOrientation;
    [SerializeField] private float controllerSensitivity;

    private Vector2 turn;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        turn.x += Input.GetAxisRaw("ControllerLookX") * controllerSensitivity;
        turn.y += Input.GetAxisRaw("ControllerLookY") * controllerSensitivity;

        turn.y = Mathf.Clamp(turn.y, -90f, 90f);

        transform.rotation = Quaternion.Euler(turn.y, turn.x, 0);
        playerOrientation.rotation = Quaternion.Euler(0, turn.x, 0);
    }
}
