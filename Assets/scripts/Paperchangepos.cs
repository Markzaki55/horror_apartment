using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paperchangepos : MonoBehaviour
{
     public List<GameObject> objectsToRandomize;
    public List<Transform> randomPositions;

    private void Start()
    {
        ShufflePositions();
        AssignPositions();
    }

    private void ShufflePositions()
    {
       
        for (int i = 0; i < randomPositions.Count; i++)
        {
            Transform temp = randomPositions[i];
            int randomIndex = Random.Range(i, randomPositions.Count);
            randomPositions[i] = randomPositions[randomIndex];
            randomPositions[randomIndex] = temp;
        }
    }

    private void AssignPositions()
    {
        // Assign each object to a random position
        for (int i = 0; i < objectsToRandomize.Count; i++)
        {
            int randomIndex = Random.Range(0, randomPositions.Count);
            objectsToRandomize[i].transform.position = randomPositions[randomIndex].position;
            randomPositions.RemoveAt(randomIndex);
        }
    }
}