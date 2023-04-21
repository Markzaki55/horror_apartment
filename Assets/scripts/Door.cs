using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class Door : MonoBehaviour, iintracatable
{
    public float openAngle = 180f;
    public float closeAngle = 0.0f; 
    public float smooth = 39.0f; 
    public bool open = false;

    private Quaternion originalRotation;

    private void Start()
    {
        originalRotation = transform.rotation;

    }

    public void Interact()
    {
        if (open)
        {
            CloseDoor();
        }
        else
        {
            OpenDoor();
        }
    }

   private void OpenDoor()
{
    Quaternion targetRotation = Quaternion.Euler(0.0f, openAngle, 0.0f);
    transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, smooth * Time.deltaTime);
    open = true;
}

private void CloseDoor()
{
    Quaternion targetRotation = Quaternion.Euler(0.0f, closeAngle, 0.0f);
    transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, smooth * Time.deltaTime);
    open = false;
}
}
