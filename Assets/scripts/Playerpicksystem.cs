using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Playerpicksystem : MonoBehaviour
{
    public float pickupDistance = 2f;
    public LayerMask pickupLayer;
    public TextMeshProUGUI PickText; 
    private IPickupable heldObject;
    private RaycastHit hit;

    void Update()
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
        
        if (Physics.Raycast(transform.position, transform.forward, out hit, pickupDistance, pickupLayer))
        {
            IPickupable pickupable = hit.collider.gameObject.GetComponent<IPickupable>();
            if (pickupable != null && heldObject == null)
            {
                PickText.gameObject.SetActive(true);
                PickText.text = "Press Q to pick up";
            }
        }
        else
        {
            PickText.gameObject.SetActive(false);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, transform.forward * pickupDistance);
    }
}