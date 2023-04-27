using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class boxdialouge1 : MonoBehaviour
{
  public TextMeshProUGUI thetext;
   
private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            thetext.text = "whats is that in the window !!!";
          //  SoundManager.PlaySound("shock");
            thetext.gameObject.SetActive(true);
            Destroy(gameObject,2.5f
            );

        }
    }
   
    private void OnDestroy()
    {
        if(thetext != null){
        thetext.gameObject.SetActive(false);
        }
            }
}

