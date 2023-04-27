using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLights : MonoBehaviour
{
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

        if (areLightsOn)
        {
            StartCoroutine(TurnOffLightsAfterDelay(6f));
        }
    }

    private IEnumerator TurnOffLightsAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        foreach (GameObject lightObject in lightObjects)
        {
            lightObject.SetActive(false);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            iswork = true;
        }
    }
}