using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulpitGenerator : MonoBehaviour
{
    public GameObject pulpitPrefab; // The Pulpit prefab to spawn
    public Transform doofusTransform; // Reference to Doofus's Transform
    public float spawnThreshold = 1f; // Time left before spawning a new pulpit

    private GameObject lastPulpit;

    void Update()
    {
        // Check if lastPulpit is null or if its lifespan is below the spawn threshold
        if (lastPulpit == null || (lastPulpit.GetComponent<PulpitController>() != null && lastPulpit.GetComponent<PulpitController>().lifespan <= spawnThreshold))
        {
            SpawnNewPulpit();
        }
    }

    void SpawnNewPulpit()
    {
        if (doofusTransform == null)
        {
            Debug.LogError("Doofus Transform is not assigned in the Inspector!");
            return;
        }

        // Determine the spawn position
        Vector3 spawnPosition;

        if (lastPulpit != null)
        {
            // Spawn the new pulpit adjacent to the last one, but keep the Y position fixed
            spawnPosition = lastPulpit.transform.position + GetRandomAdjacentPosition();
        }
        else
        {
            // Spawn the first pulpit adjacent to Doofus's position, but keep the Y position fixed
            spawnPosition = doofusTransform.position + GetRandomAdjacentPosition();
        }

        // Fix the Y position to match the known Pulpit Y level
        spawnPosition.y = -1.072927f;

        // Spawn the new pulpit
        lastPulpit = Instantiate(pulpitPrefab, spawnPosition, Quaternion.identity);

    }

    Vector3 GetRandomAdjacentPosition()
    {
        // Randomly select an adjacent position (but not the same position)
        int randomDirection = Random.Range(0, 4);
        switch (randomDirection)
        {
            case 0: return Vector3.forward * 9f;
            case 1: return Vector3.back * 9f;
            case 2: return Vector3.left * 9f;
            case 3: return Vector3.right * 9f;
            default: return Vector3.zero;
        }
    }
}
