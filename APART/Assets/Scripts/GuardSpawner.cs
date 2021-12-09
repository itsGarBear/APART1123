using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardSpawner : MonoBehaviour
{
    public Guard guardPrefab;

    public void SpawnGuard()
    {
        Instantiate(guardPrefab, transform);
    }
}
