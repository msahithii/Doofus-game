using UnityEngine;
using System.Collections.Generic;

public class PulpitSpawner : MonoBehaviour
{
    public GameObject pulpitPrefab;
    public Transform doofusTransform;
    public float spawnThreshold = 1f; // Time left before spawning a new pulpit

    private List<GameObject> activePulpits = new List<GameObject>(); // List to track current Pulpits

    void Start()
    {
        // Initialize the first pulpit
        SpawnNewPulpit(Vector3.zero);
    }

    void Update()
    {
        if (activePulpits.Count < 2 && (activePulpits.Count == 0 || activePulpits[activePulpits.Count - 1].GetComponent<PulpitController>().lifespan <= spawnThreshold))
        {
            SpawnNewPulpit(activePulpits[activePulpits.Count - 1].transform.position);
        }
    }

    void SpawnNewPulpit(Vector3 currentPosition)
    {
        Vector3 spawnPosition = currentPosition + GetRandomAdjacentPosition();
        GameObject newPulpit = Instantiate(pulpitPrefab, spawnPosition, Quaternion.identity);
        activePulpits.Add(newPulpit);

        // Ensure only 2 pulpits exist at a time
        if (activePulpits.Count > 2)
        {
            Destroy(activePulpits[0]); // Destroy the oldest pulpit
            activePulpits.RemoveAt(0); // Remove it from the list
        }
    }

    Vector3 GetRandomAdjacentPosition()
    {
        // Set a fixed distance between pulpits (same level)
        float distance = 9f;

        // Randomly select an adjacent position (keeping Y the same)
        int randomDirection = Random.Range(0, 4);
        switch (randomDirection)
        {
            case 0: return new Vector3(0, 0, distance);  // Forward
            case 1: return new Vector3(0, 0, -distance); // Backward
            case 2: return new Vector3(-distance, 0, 0); // Left
            case 3: return new Vector3(distance, 0, 0);  // Right
            default: return Vector3.zero;
        }
    }
}
