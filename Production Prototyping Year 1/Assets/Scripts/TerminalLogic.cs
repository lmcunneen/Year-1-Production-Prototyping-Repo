using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerminalLogic : MonoBehaviour
{
    [Header("Game Objects")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cameraHolder;
    [SerializeField] private GameObject crosshair;
    [SerializeField] private GameObject terminalExitText;

    [Header("Terminal Parameters")]
    [SerializeField] private Text terminalText;
    [SerializeField] private Transform terminalCameraPosition;
    [SerializeField] private string correctTerminalInput;

    private GameObject interactObjectsHolderReference;
    
    private bool isActive = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (isActive)
        {
            CheckKeyboardInput();

            if (terminalText.text == correctTerminalInput)
            {
                StartCoroutine(SuccessfulInput());
            }
        }
    }

    public void ActivateTerminal(GameObject interactObjectsHolder)
    {
        player.GetComponent<PlayerMovement>().enabled = false;

        cameraHolder.GetComponent<FollowTransform>().enabled = false;
        cameraHolder.GetComponent<PlayerCamera>().enabled = false;
        cameraHolder.transform.position = terminalCameraPosition.position;
        cameraHolder.transform.rotation = terminalCameraPosition.rotation;

        crosshair.SetActive(false);
        terminalExitText.SetActive(true);

        interactObjectsHolderReference = interactObjectsHolder;

        StartCoroutine(WaitBeforeActivatingInput());
    }

    public void DeactivateTerminal(bool isLocked)
    {
        player.GetComponent<PlayerMovement>().enabled = true;

        cameraHolder.GetComponent<FollowTransform>().enabled = true;
        cameraHolder.GetComponent<PlayerCamera>().enabled = true;

        crosshair.SetActive(true);
        terminalExitText.SetActive(false);

        interactObjectsHolderReference.GetComponent<InteractObjects>().DetectionValidator(true);

        isActive = false;

        if (isLocked)
        {
            gameObject.tag = "Untagged";

            GetComponent<Interactable>().enabled = false;  
            this.enabled = false;
        }
    }
    
    private void CheckKeyboardInput()
    {
        if (Input.anyKeyDown)
        {
            string keysPressed = Input.inputString;

            if (keysPressed.Length == 1)
            {
                EnterLetter(keysPressed);
            }
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            DeleteLetter();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DeactivateTerminal(false);
        }
    }

    private void EnterLetter(string typedLetter)
    {
        terminalText.text += typedLetter;
    }

    private void DeleteLetter()
    {
        terminalText.text = terminalText.text.Remove(terminalText.text.Length - 2);
    }

    IEnumerator WaitBeforeActivatingInput()
    {
        //Since you can interact with a key also, this prevents that same interact key being typed into the terminal upon interaction
        yield return new WaitForEndOfFrame();
        isActive = true;
    }    
    IEnumerator SuccessfulInput()
    {
        terminalText.color = Color.green;
        isActive = false;
        yield return new WaitForSeconds(1f);
        DeactivateTerminal(true);
    }
}
