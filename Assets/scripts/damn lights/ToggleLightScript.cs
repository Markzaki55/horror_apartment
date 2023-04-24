using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLightScript : MonoBehaviour
{
    public List<Light> lightObjects;
    public Light flashlightred;
    private bool lightsOn = true;
    private int collisionCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SoundManager.PlaySound("click");
            foreach (Light lightObject in lightObjects)
            {
                lightObject.gameObject.SetActive(lightsOn);
            }
            flashlightred.gameObject.SetActive(!lightsOn);
            lightsOn = !lightsOn;
            collisionCount++;

            if (collisionCount >= 2)
            {
                Destroy(gameObject);
            }
        }
    }
}