using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableObject : MonoBehaviour, IPickupable
{
    private Rigidbody rb;
    private Vector3 originalPosition;
    private bool isHeld = false;
    private Transform holder;
    public float dropOffset = 1.0f;
    public LayerMask pickupLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalPosition = transform.position;
    }

    public void OnPickup()
    {
        rb.isKinematic = true;
        isHeld = true;
        holder = Camera.main.transform ;
      transform.position = holder.position + holder.forward * 0.5f;
    }

   public void OnDrop()
{
    rb.isKinematic = false;
    rb.velocity = holder.forward * 10f; 
    transform.position = holder.position + holder.forward * dropOffset;
    transform.rotation = holder.rotation;
    holder = null;
}

    void Update()
    {
        if (isHeld)
        {
            transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2f;
            transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isHeld && pickupLayer == (pickupLayer | (1 << collision.gameObject.layer)))
        {
            originalPosition = transform.position;
        }
    }
}