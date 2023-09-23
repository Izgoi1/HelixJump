using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : Platform
{
    [SerializeField] private Ball ball;
    [SerializeField] private Transform spawnBall;

    private void Awake()
    {
        Instantiate(ball, spawnBall.position, Quaternion.identity);
    }

}
