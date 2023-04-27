// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using TMPro;

// public class Playerpicksystem : MonoBehaviour
// {
//     [SerializeField] private float pickupDistance = 2f;
//     [SerializeField] private LayerMask pickupLayer;
//     [SerializeField] private TextMeshProUGUI pickText; 
//     private IPickupable heldObject;
//     private RaycastHit hit;

//     private void Update()
//     {
//         HandlePickup();
//         HandlePickupText();
//     }

//     private void HandlePickup()
//     {
//         if (Input.GetKeyDown(KeyCode.Q))
//         {
//             if (heldObject == null)
//             {
//                 if (Physics.Raycast(transform.position, transform.forward, out hit, pickupDistance, pickupLayer))
//                 {
//                     heldObject = hit.collider.gameObject.GetComponent<IPickupable>();
//                     if (heldObject != null)
//                     {
//                         heldObject.OnPickup();
//                     }
//                 }
//             }
//             else
//             {
//                 heldObject.OnDrop();
//                 heldObject = null;
//             }
//         }
//     }

//     private void HandlePickupText()
//     {
//         if (heldObject == null)
//         {
//             if (Physics.Raycast(transform.position, transform.forward, out hit, pickupDistance, pickupLayer))
//             {
//                 IPickupable pickupable = hit.collider.gameObject.GetComponent<IPickupable>();
//                 if (pickupable != null)
//                 {
//                     pickText.gameObject.SetActive(true);
//                     pickText.text = "Press Q to pick up";
//                 }
//             }
//             else
//             {
//                 pickText.gameObject.SetActive(false);
//             }
//         }
//         else
//         {
//             pickText.gameObject.SetActive(true);
//             pickText.text = "Press Q to drop";
//         }
//     }

//     private void OnDrawGizmosSelected()
//     {
//         Gizmos.color = Color.yellow;
//         Gizmos.DrawRay(transform.position, transform.forward * pickupDistance);
//     }
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Playerpicksystem : MonoBehaviour
{
    [SerializeField] private float pickupDistance = 2f;
    [SerializeField] private LayerMask pickupLayer;
    [SerializeField] private Vector3 raycastSize = new Vector3(0.2f, 0.2f, 2.0f);
    [SerializeField] private TextMeshProUGUI pickText; 
    private IPickupable heldObject;
    private Collider[] hits;

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
                hits = Physics.OverlapBox(transform.position + transform.forward * pickupDistance / 2f, raycastSize / 2f, transform.rotation, pickupLayer);
                if (hits.Length > 0)
                {
                    heldObject = hits[0].gameObject.GetComponent<IPickupable>();
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
        if (heldObject == null)
        {
            hits = Physics.OverlapBox(transform.position + transform.forward * pickupDistance / 2f, raycastSize / 2f, transform.rotation, pickupLayer);
            if (hits.Length > 0)
            {
                IPickupable pickupable = hits[0].gameObject.GetComponent<IPickupable>();
                if (pickupable != null)
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
        else
        {
            pickText.gameObject.SetActive(true);
            pickText.text = "Press Q to drop";
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawWireCube(Vector3.forward * pickupDistance / 2f, raycastSize);
    }
}