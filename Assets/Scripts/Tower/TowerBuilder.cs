using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int levelCount;

    [SerializeField] private float additionalScale;
    [SerializeField] private GameObject beam;
    [SerializeField] private SpawnPlatform spawnPlatform;
    [SerializeField] private Platform[] platform;
    [SerializeField] private FinishPlatform finishPlatform;
    private float startAndFinishAdditionalScale = 0.5f;

    public float BeamScaleY => levelCount / 2f + startAndFinishAdditionalScale + additionalScale /2;
    private void Awake()
    {
        Build();
    }
    private void Build()
    {
        GameObject beamCopy = Instantiate(beam, transform);
        beamCopy.transform.localScale = new Vector3(1, BeamScaleY, 1);

        Vector3 spawnPosition = beamCopy.transform.position;
        spawnPosition.y += beamCopy.transform.localScale.y - additionalScale;

        SpawnPlatform(spawnPlatform, ref spawnPosition, beamCopy.transform);

        for (int i = 0; i < levelCount; i++)
        {
            SpawnPlatform(platform[Random.Range(0, platform.Length)], ref spawnPosition, beamCopy.transform);
        }

        SpawnPlatform(finishPlatform, ref spawnPosition, beamCopy.transform);
    }

    private void SpawnPlatform(Platform platform, ref Vector3 spawnPosition, Transform parent)
    {
        Instantiate(platform, spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0), parent);
        spawnPosition.y -= 1;
    }
}




