



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
        holder = GameObject.Find("Holder").transform;
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