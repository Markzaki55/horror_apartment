using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLightScene : MonoBehaviour
{
    private List<Light> allLights = new List<Light>();
    private Dictionary<Light, Color> originalColors = new Dictionary<Light, Color>();

    public void TurnLightsRed()
    {
        // Find all the light objects in the scene and add them to the list
        foreach (GameObject obj in UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects())
        {
            foreach (Light light in obj.GetComponentsInChildren<Light>())
            {
                allLights.Add(light);
                originalColors[light] = light.color;
                light.color = Color.red;
            }
        }
    }

    public void RestoreOriginalColors()
    {
        // Restore the original colors of all the lights in the scene
        foreach (KeyValuePair<Light, Color> pair in originalColors)
        {
            pair.Key.color = pair.Value;
        }

        allLights.Clear();
        originalColors.Clear();
    }
}