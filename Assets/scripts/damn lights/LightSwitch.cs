using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public List<GameObject> lightObjects = new List<GameObject>();
    public bool cutTheLight = false;

    public void SetLightsInactive()
    {
        foreach (GameObject lightObject in lightObjects)
        {
            lightObject.SetActive(false);
        }
    }

    public void SetLightsActive()
    {
        foreach (GameObject lightObject in lightObjects)
        {
            lightObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (cutTheLight)
        {
            SetLightsInactive();
        }
        else
        {
            SetLightsActive();
        }
    }
}