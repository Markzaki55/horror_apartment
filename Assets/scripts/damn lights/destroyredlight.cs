using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class destroyredlight : MonoBehaviour
{
    public TextMeshProUGUI thetext;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            thetext.text = "i have to find the breaker so i can turn the lights on!";
            thetext.gameObject.SetActive(true);
            Destroy(gameObject,3
            );

        }
    }
   
    private void OnDestroy()
    {
        if(thetext !=null)
        {
        thetext.gameObject.SetActive(false);
        }
            }
}
