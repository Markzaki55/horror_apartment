using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Flashlight : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI flashtext;
    [SerializeField] private Light flashlight;
    private bool isOn ;
    private PickupableObject pickableObject;

    private void Start()
    {
        
        flashlight.enabled = false;
        pickableObject = GetComponent<PickupableObject>();
    }
    // private void Update()
    // {
        
    //     flashtext.gameObject.SetActive(false);
    //    if (pickableObject && pickableObject.isHeld)
    //     {
           
                
    //             flashtext.gameObject.SetActive(false);
              
    //     }
    //     else
    //     {
            
            
         
    //     if(isOn && pickableObject.isHeld);
    //     }
    //     {
            
    //         flashtext.gameObject.SetActive(false);

    //     } if(!isOn && pickableObject.isHeld){
            
    //         flashtext.gameObject.SetActive(true);
    //     }
    
    // }

    private void Update()
    {
        flashtext.gameObject.SetActive(false);
        if (Input.GetKeyDown(KeyCode.F)&&pickableObject.isHeld )
        {
            SoundManager.PlaySound("click");
        }

       
        if (pickableObject && pickableObject.isHeld)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                
                flashtext.gameObject.SetActive(false);
                isOn = !isOn;
                flashlight.enabled = isOn;
            }
        }
        else
        {
            ;
            
           
            isOn = false;
            flashlight.enabled = false;
        }
        if(isOn && pickableObject.isHeld)
        {
            
            flashtext.gameObject.SetActive(false);

        }else if(!isOn && pickableObject.isHeld){
            
            flashtext.gameObject.SetActive(true);
        }
    }

    // for android
    //     public void flashlightlight()
    // {
    //     if (pickableObject.isHeld )
    //     {
    //         SoundManager.PlaySound("click");
    //     }

       
    //     if (pickableObject && pickableObject.isHeld)
    //     {
           
                
    //             flashtext.gameObject.SetActive(false);
    //             isOn = !isOn;
    //             flashlight.enabled = isOn;
            
    //     }
    //     else
    //     {
    //         ;
            
           
    //         isOn = false;
    //         flashlight.enabled = false;
    //     }
    //     if(isOn && pickableObject.isHeld)
    //     {
            
    //         flashtext.gameObject.SetActive(false);

    //     }else if(!isOn && pickableObject.isHeld){
            
    //         flashtext.gameObject.SetActive(true);
    //     }
    // }
}