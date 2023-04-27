
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public float interactDistance = 2.0f;
    public TextMeshProUGUI interactText; 
    private Camera playerCamera;

    private void Start()
    {
        playerCamera = Camera.main;
        interactText.gameObject.SetActive(false); 
    }

    private void Update()
    {

        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {

            iintracatable interactable = hit.collider.GetComponent<iintracatable>();
            if (interactable != null)
            {  if (interactable.GetType() == typeof(ReadNotes))
                {
                    interactText.gameObject.SetActive(true); 
                    interactText.text = "Press E to pick the note"; 
                }
                else
                {
                    interactText.gameObject.SetActive(true); 
                    interactText.text = "Press E to interact"; 
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                }
            }
            else
            {
                 interactText.gameObject.SetActive(false); 
            }
        }
        else
        {
             interactText.gameObject.SetActive(false); 
        }
    }
}