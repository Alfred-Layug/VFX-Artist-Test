using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject firePoint;
    [SerializeField] private List<GameObject> visualEffects = new ();
    [SerializeField] private float spawnDelay = 1f;

    private GameObject effectToSpawn;

    private void Start()
    {
        effectToSpawn = visualEffects[0];
        StartCoroutine(SpawnVFXTimer());
    }

    private IEnumerator SpawnVFXTimer()
    {
        yield return new WaitForSeconds(spawnDelay);

        GameObject vfx = Instantiate(effectToSpawn, firePoint.transform.position, firePoint.transform.rotation);
    }
}