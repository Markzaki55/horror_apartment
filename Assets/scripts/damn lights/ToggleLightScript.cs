using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ToggleLightScript : MonoBehaviour
{
    public List<Light> lightObjects;
    [SerializeField]private TextMeshProUGUI thetext;
    public Light flashlightred;
    [SerializeField] private bool lightsOn = false;
    private int collisionCount = 0;


private void OnDestroy()
{if(thetext !=null)
{
    thetext.gameObject.SetActive(false);
}
}
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
            SoundManager.PlaySound("shock");
            thetext.text="what the fuck is HAPPINING!!!!";
            thetext.gameObject.SetActive(true);

            lightsOn = !lightsOn;
            collisionCount++;

            if (collisionCount >= 1)
            {
                Destroy(gameObject,2);
            }
           
        }
    }
}