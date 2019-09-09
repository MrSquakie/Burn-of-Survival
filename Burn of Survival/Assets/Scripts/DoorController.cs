using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator doorController;
    public bool isAnimating = false;

    private bool toggle = false;

    public void Start()
    {
        doorController = GetComponent<Animator>();
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && toggle)
        {
            openDoor();
            print("open");
            toggle = !toggle;

        }
        else if (Input.GetKeyDown(KeyCode.C) && !toggle)
        {
            closeDoor();
            toggle = !toggle;
            print("close");

        }
    }

    public void openDoor()
    {
        doorController.SetBool("open", true);
    }

    public void closeDoor()
    {
        doorController.SetBool("open", false);

    }
}
