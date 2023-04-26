using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLights : MonoBehaviour
{

    // by mistake i made it a flickering script LOL


    public List<GameObject> lightObjects = new List<GameObject>();
    public bool areLightsOn = true;
    public bool iswork;


    public void ToggleLights()
    {
        areLightsOn = !areLightsOn;
        foreach (GameObject lightObject in lightObjects)
        {
            lightObject.SetActive(areLightsOn);
        }
    }

    private void Update()
    {
        // Check for input to toggle lights
        if (iswork)
        {
            ToggleLights();
            Destroy(gameObject, 6);
        }
    }
}