using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Playables;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private GameObject releaseVFXPrefab;
    [SerializeField] private GameObject impactVFXPrefab;

    private void Start()
    {
        GameObject releaseVFX = Instantiate(releaseVFXPrefab, transform.position, Quaternion.identity);
        releaseVFX.transform.forward = gameObject.transform.forward;
    }

    private void Update()
    {
        transform.position += transform.forward * (speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.GetComponent<PlayableDirector>()) return;
        
        speed = 0;

        Vector3 closestPoint = other.ClosestPoint(transform.position);
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, closestPoint.normalized);

        GameObject impactVFX = Instantiate(impactVFXPrefab, closestPoint, rotation);
        
        Destroy(gameObject);
    }
}