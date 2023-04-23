using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour, IPickupable
{
    public Light flashlightLight;

    private bool isOn = false;

    void Start()
    {
        flashlightLight.enabled = false;
    }

    public void OnPickup()
    {
        if (isOn)
        {
            flashlightLight.enabled = true;
        }
    }

    public void OnDrop()
    {
        flashlightLight.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isOn = !isOn;
            flashlightLight.enabled = isOn;
        }
    }
}