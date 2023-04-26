using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class rabidly : MonoBehaviour
{
    public float interactionInterval = 0.3f; // the time interval between each interaction
    public float duration = 6.0f; // the duration of the horror moment

    public bool testHorrorMoment = false; // a bool to trigger the horror moment for testing

    private float timer = 0.0f;
    private bool isInteracting = false;

    public void StartHorrorMoment()
    {
        timer = 0.0f;
        isInteracting = true;
    }

    public void StopHorrorMoment()
    {
        isInteracting = false;
    }

    private void Update()
    {
        if (testHorrorMoment)
        {
            StartHorrorMoment();
            testHorrorMoment = false; // reset the bool after triggering the horror moment
        }

        if (isInteracting)
        {
            timer += Time.deltaTime;
            if (timer >= duration)
            {
                StopHorrorMoment();
                return;
            }

            if (timer % interactionInterval < Time.deltaTime)
            {
                // call the Interact function on all objects with a component implementing the IInteractable interface
              iintracatable[] interactables = FindObjectsOfType<MonoBehaviour>().OfType<iintracatable>().ToArray();

                foreach (iintracatable interactable in interactables)
                {
                    interactable.Interact();
                }
        }
    }
    }}

