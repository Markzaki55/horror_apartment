using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterspawndoor : MonoBehaviour
{
    public GameObject prefabToInstantiate;
    public Transform spawnPoint;
    public float rotationSpeed = 10.0f;
    private bool hasCollided = false;
    public FirstPersonController playerControl;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerControl = player.GetComponent<FirstPersonController>();
    }

    void OnCollisionEnter(Collision collision)
    {

        Cursor.lockState = CursorLockMode.None;
        if (collision.gameObject.CompareTag("Player") && !hasCollided)
        {
            // Disable the PlayerControl script
            playerControl.enabled = false;

            // Instantiate the prefab at the spawn point
            Instantiate(prefabToInstantiate, spawnPoint.position, spawnPoint.rotation);

            // Rotate the player object by 180 degrees on the Y axis over time
            Quaternion targetRotation = Quaternion.Euler(0.0f, 270.0f, 0.0f);
            StartCoroutine(RotatePlayer(targetRotation));

            // Set the hasCollided flag to true to prevent multiple collisions
            hasCollided = true;
        }
    }

    IEnumerator RotatePlayer(Quaternion targetRotation)
    {
        while (Quaternion.Angle(playerControl.transform.rotation, targetRotation) > 0.01f)
        {
            playerControl.transform.rotation = Quaternion.Slerp(playerControl.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            yield return null;
        }
    }
}