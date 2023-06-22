using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchKey : MonoBehaviour, iintracatable
{
    public List<Light> lightObjects; 
    private bool lightsOn = true; 

    public void Interact()
    {
        SoundManager.PlaySound("click");
        if (lightsOn)
        {
          
            foreach (Light light in lightObjects)
            {
                light.gameObject.SetActive(false);
            }
            lightsOn = false;
        }
        else
        {
           
            foreach (Light light in lightObjects)
            {
                light.gameObject.SetActive(true);
            }
            lightsOn = true;
        }
    }
}