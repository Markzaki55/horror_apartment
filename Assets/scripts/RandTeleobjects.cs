using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandTeleobjects : MonoBehaviour
{
    [SerializeField] private List<Transform> positionsList1;
    [SerializeField] private List<Transform> positionsList2;
    [SerializeField] private float minTeleportTime = 1f;
    [SerializeField] private float maxTeleportTime = 5f;

    private Transform currentTarget;
    private float timeToTeleport = 0f;

    private static List<Transform> occupiedPositions = new List<Transform>();

    private void Start()
    {
        timeToTeleport = Random.Range(minTeleportTime, maxTeleportTime);
        SetNewTarget();
    }

    private void Update()
    {
        if (timeToTeleport <= 0f)
        {
            SetNewTarget();
            timeToTeleport = Random.Range(minTeleportTime, maxTeleportTime);
        }

        timeToTeleport -= Time.deltaTime;
    }

    private void SetNewTarget()
    {
        List<Transform> currentList = (Random.value < 0.5f) ? positionsList1 : positionsList2;
        Transform newTarget = currentList[Random.Range(0, currentList.Count)];

        while (newTarget.position == currentTarget.position || occupiedPositions.Contains(newTarget))
        {
            newTarget = currentList[Random.Range(0, currentList.Count)];
        }

        if (currentTarget != null)
        {
            occupiedPositions.Remove(currentTarget);
        }

        currentTarget = newTarget;
        occupiedPositions.Add(currentTarget);

        transform.position = currentTarget.position;
    }
}