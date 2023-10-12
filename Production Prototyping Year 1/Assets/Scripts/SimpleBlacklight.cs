using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBlacklight : MonoBehaviour
{
    public GameObject blacklight;
    public GameObject text;

    private bool powerState = false;

    private void Start()
    {
        blacklight.SetActive(false);
        text.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            powerState = !powerState;
            TurnOnAndOff(powerState);
        }
    }

    void TurnOnAndOff(bool input)
    {
        blacklight.SetActive(input);
        text.SetActive(input);
    }
}
