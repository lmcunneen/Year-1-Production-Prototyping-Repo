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

    public void InteractSuccess(KeyCode interactKey, GameObject interactObjectsHolder)
    {
        if (objectType == "IsHoldable")
        {
            GetComponent<HoldableObject>().StartHolding(interactKey, interactObjectsHolder);
            interactObjectsHolder.GetComponent<InteractObjects>().DetectionValidator(false);
        }

        else if (objectType == "IsTerminal")
        {
            GetComponent<TerminalLogic>().ActivateTerminal(interactObjectsHolder);
            interactObjectsHolder.GetComponent<InteractObjects>().DetectionValidator(false);
        }

        else if (objectType == "IsShadow")
        {
            GetComponent<ShadowPuzzle>().ActivateShadowPuzzle(interactObjectsHolder);
            interactObjectsHolder.GetComponent<InteractObjects>().DetectionValidator(false);
        }
    }
}
