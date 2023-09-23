using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int levelCount;
    [SerializeField] private int additionalScale;
    [SerializeField] private GameObject _beam;
    [SerializeField] private SpawnPlatform spawnPlatform;
    [SerializeField] private FinishPlatform finishPlatform;
    [SerializeField] private Platform[] platform;

    private float startAndFinishAddittionalScale = 0.5f;
    public float beamScaleY => levelCount / 2f + startAndFinishAddittionalScale + additionalScale;

    private void Awake()
    {
        Build();
    }

    private void Build()
    {
       GameObject beam = Instantiate(_beam, transform);
        beam.transform.localScale = new Vector3 (1f, beamScaleY, 1f);

        Vector3 spawnPosition = beam.transform.position;
        spawnPosition.y = beam.transform.localScale.y - additionalScale;

        SpawnPlatform(spawnPlatform, ref spawnPosition, beam.transform);

        for (int i = 0; i < levelCount; i++)
        {
            SpawnPlatform(platform[Random.Range(0, platform.Length)], ref spawnPosition, beam.transform);
        }

        SpawnPlatform(finishPlatform, ref spawnPosition, beam.transform);
    }

    private void SpawnPlatform(Platform platform,ref Vector3 spawnPosition,Transform parent)
    {
        platform = Instantiate(platform, spawnPosition,Quaternion.Euler(0, Random.Range(0, 360), 0), parent);
        spawnPosition.y -= 0.5f;
        platform.transform.localScale = new Vector3(1f, 0.4f, 1f);
    }
}
