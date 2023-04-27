using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CircuitBreaker : MonoBehaviour, iintracatable
{
    [SerializeField] GameObject[] lights;
    public void Interact()
    {
        SoundManager.PlaySound("click");
        Debug.Log("worked");

        foreach (GameObject light in lights)
        {
            if (!light.activeSelf)
            {
                light.SetActive(true);
            }
        }

    }
}