using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private string objectType;

    void Start()
    {
        objectType = gameObject.tag;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InteractSuccess(KeyCode interactKey)
    {
        if (objectType == "IsHoldable")
        {
            GetComponent<HoldableObject>().StartHolding(interactKey);
        }

        else if (objectType == "IsTerminal")
        {
            GetComponent<TerminalLogic>().ActivateTerminal();
        }
    }
}
