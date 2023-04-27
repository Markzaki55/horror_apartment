using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchKey : MonoBehaviour, iintracatable
{
    public List<Light> lightObjects; // List of game objects with light components

    private bool lightsOn = true; // Whether the lights are currently on

    public void Interact()
    {
        SoundManager.PlaySound("click");
        if (lightsOn)
        {
            // loop through each light and turn it off
            foreach (Light light in lightObjects)
            {
                light.gameObject.SetActive(false);
            }
            lightsOn = false;
        }
        else
        {
            // loop through each light and turn it on
            foreach (Light light in lightObjects)
            {
                light.gameObject.SetActive(true);
            }
            lightsOn = true;
        }
    }
}