using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadNotes : MonoBehaviour, iintracatable
{
    public GameObject player;
    public GameObject noteUI;
  

    void Start()
    {
        noteUI.SetActive(false);
    }

    public void Interact()
    {
        noteUI.SetActive(true);
        SoundManager.PlaySound("paper1");
        player.GetComponent<FirstPersonController>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ExitButton()
    {
        papercounter.papercount +=1;
        SoundManager.PlaySound("paper2");
        noteUI.SetActive(false);
        player.GetComponent<FirstPersonController>().enabled = true;
                Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Destroy(gameObject,0.4f);
        

    }
}