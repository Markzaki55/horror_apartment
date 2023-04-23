// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PickupableObject : MonoBehaviour, IPickupable
// {
//     private Rigidbody rb;
//     private Vector3 originalPosition;
//     private bool isHeld = false;
//     private Transform holder;
//     public float dropOffset = 1.0f;
//     public LayerMask pickupLayer;

//     void Start()
//     {
//         rb = GetComponent<Rigidbody>();
//         originalPosition = transform.position;
//     }

//     public void OnPickup()
//     {
//         rb.isKinematic = true;
//         isHeld = true;
//         holder = Camera.main.transform  ;
//     }

//     public void OnDrop()
//     {
//         rb.isKinematic = false;
//         rb.velocity = holder.forward * 5f; 
//         transform.position = holder.position + holder.forward * dropOffset;
//         transform.rotation = holder.rotation;
//         isHeld = false;
//         holder = null;
//     }

//     void Update()
//     {
//         if (isHeld)
//         {
//             transform.position = Camera.main.transform.position + Camera.main.transform.forward * 0.8f;
//             transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
//         }
//     }

//     void OnCollisionEnter(Collision collision)
//     {
//         if (!isHeld && pickupLayer == (pickupLayer | (1 << collision.gameObject.layer)))
//         {
//             originalPosition = transform.position;
//         }
//     }
// }











// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PickupableObject : MonoBehaviour, IPickupable
// {
//     private Rigidbody rb;
//     private Vector3 originalPosition;
//     private bool isHeld = false;
//     private Transform holder;
//     public float dropOffset = 1.0f;
//     public float dropForce = 4.0f;

//     private Camera maincam;
//     void Start()
//     {
//         maincam = Camera.main;
//         rb = GetComponent<Rigidbody>();
//         originalPosition = transform.position;
//     }

//     public void OnPickup()
//     {
        
//         rb.isKinematic = true;
//         isHeld = true;
//         holder = maincam.transform;
//         // transform.position = holder.position + holder.forward * 0.5f - holder.up * 0.2f;
//     }

//    public void OnDrop()
// {
//     rb.isKinematic = false;
//     rb.AddForce(holder.forward * dropForce, ForceMode.Impulse);
//    // transform.position = holder.position + holder.forward * dropOffset;
//   //  transform.rotation = holder.rotation;
//     isHeld = false;
//     holder = null;
// }


//     void Update()
//     {
//         if (isHeld)
//         {
//             transform.position =maincam.transform.position + maincam.transform.forward * 0.2f - maincam.transform.up*0.2f;
//             transform.rotation = Quaternion.LookRotation(transform.position -maincam.transform.position);
//         }
//     }

//     void OnCollisionEnter(Collision collision)
//     {
//         if (!isHeld)
//         {
//             originalPosition = transform.position;
//         }
//     }
// }



using UnityEngine;

public class PickupableObject  : MonoBehaviour, IPickupable
{

    
      private Rigidbody rb;
    private Vector3 originalPosition;
    public bool isHeld = false;
    private Transform holder;
    private float dropOffset = 1.0f;
    private float dropForce = 4.0f;

     [SerializeField] private Vector3 heldPosition = new Vector3(0.2f, 0.1f, 1f);
    [SerializeField] private Vector3 heldRotation = new Vector3(0, -180, 0);

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalPosition = transform.position;
    }

    public void OnPickup()
    {
        rb.isKinematic = true;
        isHeld = true;
        holder = GameObject.FindGameObjectWithTag("Player").transform;
        transform.SetParent(holder.GetChild(0));
    }

    public void OnDrop()
    {
        if (isHeld)
        {
            rb.isKinematic = false;
            rb.AddForce(holder.forward * dropForce, ForceMode.Impulse);
            transform.position = holder.position + holder.forward * dropOffset;
            transform.rotation = holder.rotation;
            isHeld = false;
            holder = null;
             transform.SetParent(null);
        }
    }

    private void Update()
    {
        if (isHeld)
        {
            transform.position = holder.TransformPoint(heldPosition);
            transform.rotation = holder.rotation * Quaternion.Euler(heldRotation);
        }
    }
}