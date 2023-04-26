using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class boxdialouge2 : MonoBehaviour
{
    public TextMeshProUGUI thetext;
   
private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            thetext.text = "When you open the window, right-click to focus.";
            SoundManager.PlaySound("shock");
            thetext.gameObject.SetActive(true);
            Destroy(gameObject,2.5f
            );

        }
    }
   
    private void OnDestroy()
    {
        thetext.gameObject.SetActive(false);
            }
}

