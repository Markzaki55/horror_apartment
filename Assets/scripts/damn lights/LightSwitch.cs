using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public List<Light> allLights = new List<Light>();

    private void Start()
    {
        // Find all the light objects in the scene and add them to the list
        foreach (GameObject obj in UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects())
        {
            foreach (Light light in obj.GetComponentsInChildren<Light>())
            {
                allLights.Add(light);
            }
        }

        // Turn off all the lights in the scene
        //TurnOffAllLights();
    }

    public void TurnOffAllLights()
    {
        foreach (Light light in allLights)
        {
            light.gameObject.SetActive(false);
        }
    }

    public void TurnOnAllLights()
    {
        foreach (Light light in allLights)
        {
            light.gameObject.SetActive(true);
        }
    }
}