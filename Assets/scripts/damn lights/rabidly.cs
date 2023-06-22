using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class rabidly : MonoBehaviour
{
    public float interactionInterval = 0.3f; 
    public float duration = 6.0f; 
    public bool testHorrorMoment = false; 

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
            testHorrorMoment = false; 
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
                
              iintracatable[] interactables = FindObjectsOfType<MonoBehaviour>().OfType<iintracatable>().ToArray();

                foreach (iintracatable interactable in interactables)
                {
                    interactable.Interact();
                }
        }
    }
    }}

