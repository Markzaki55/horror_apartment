using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private GameObject objectToRespawn;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private int maxSpawnCount = 3;

    private int spawnCount = 0;
    private int currentSpawnPointIndex = 0;

    private void OnDestroy()
    {
        if (objectToRespawn != null && spawnPoints.Length > 0 && spawnCount < maxSpawnCount)
        {
            Transform spawnPoint = spawnPoints[currentSpawnPointIndex];
            GameObject spawnedObject = Instantiate(objectToRespawn, spawnPoint.position, spawnPoint.rotation);

            Respawn respawnScript = spawnedObject.GetComponent<Respawn>();
            if (respawnScript != null)
            {
                respawnScript.enabled = true;
            }

            DisappearOnLook disappearScript = spawnedObject.GetComponent<DisappearOnLook>();
            if (disappearScript != null)
            {
                disappearScript.enabled = true;
            }

            spawnedObject.SetActive(true);
            spawnedObject.transform.LookAt(Camera.main.transform);

            spawnCount++;
            currentSpawnPointIndex++;
            if (currentSpawnPointIndex >= spawnPoints.Length)
            {
                currentSpawnPointIndex = 0;
            }
        }
    }
}