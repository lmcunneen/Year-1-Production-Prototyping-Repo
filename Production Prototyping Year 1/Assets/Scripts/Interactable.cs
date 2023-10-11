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

    public void InteractSuccess()
    {
        if (objectType == "IsHoldable")
        {
            //Run holding logic in other script
        }

        else if (objectType == "IsTerminal")
        {
            GetComponent<TerminalLogic>().ActivateTerminal();
        }
    }
}
