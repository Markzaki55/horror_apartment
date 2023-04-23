using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public static Teleport instance;

    [SerializeField] private Transform[] teleportTargets = null;
    [SerializeField] private DisappearOnLook objectDisappearing = null;
    private Camera maincam;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        maincam = Camera.main;
    }
    private void Awake()
    {
        instance= this;
    }
   
    public void TeleportToRandomTarget()
    {
        if (teleportTargets == null || teleportTargets.Length == 0)
        {
            Debug.LogWarning("Teleport targets not assigned in Teleport script on " + gameObject.name);
            return;
        }

        int randomIndex = Random.Range(0, teleportTargets.Length);

        Transform teleportTarget = teleportTargets[randomIndex];
        Vector3 newPosition = teleportTarget.position;

        transform.position = newPosition;
        transform.LookAt(maincam.transform);

        if (objectDisappearing != null)
        {
            objectDisappearing.UpdatePosition(newPosition);
            objectDisappearing.CheckIfLooking();
            
        }
    }
}