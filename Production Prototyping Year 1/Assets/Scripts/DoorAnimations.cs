using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimations : MonoBehaviour
{
    public Animator door;

    private bool isActive = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isActive)
        {
            isActive = false;
            StartCoroutine(DoorAnimation());
        }
    }

    IEnumerator DoorAnimation()
    {
        door.Play("Door");
        yield return new WaitForSeconds(3f);
        door.Play("Door Close");
        yield return new WaitForSeconds(1f);
        isActive = true;
    }
}
