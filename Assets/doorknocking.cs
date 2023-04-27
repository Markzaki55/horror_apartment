using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorknocking : MonoBehaviour
{
    
    private void Start()
    {
        StartCoroutine(PlayAudioEveryTwoMinutes());
    }

    private IEnumerator PlayAudioEveryTwoMinutes()
    {
        while (true)
        {
             yield return new WaitForSeconds(100f); 
            SoundManager.PlaySound("knock");
            Debug.Log(" knocking played");
            
        }
    }
}