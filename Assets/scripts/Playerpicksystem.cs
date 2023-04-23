using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Playerpicksystem : MonoBehaviour
{
    [SerializeField] private float pickupDistance = 2f;
    [SerializeField] private LayerMask pickupLayer;
    [SerializeField] private TextMeshProUGUI pickText; 
    private IPickupable heldObject;
    private RaycastHit hit;

    private void Update()
    {
        HandlePickup();
        HandlePickupText();
    }

    private void HandlePickup()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (heldObject == null)
            {
                if (Physics.Raycast(transform.position, transform.forward, out hit, pickupDistance, pickupLayer))
                {
                    heldObject = hit.collider.gameObject.GetComponent<IPickupable>();
                    if (heldObject != null)
                    {
                        heldObject.OnPickup();
                    }
                }
            }
            else
            {
                heldObject.OnDrop();
                heldObject = null;
            }
        }
    }

    private void HandlePickupText()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, pickupDistance, pickupLayer))
        {
            IPickupable pickupable = hit.collider.gameObject.GetComponent<IPickupable>();
            if (pickupable != null && heldObject == null)
            {
                pickText.gameObject.SetActive(true);
                pickText.text = "Press Q to pick up";
            }
        }
        else
        {
            pickText.gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, transform.forward * pickupDistance);
    }
}
