using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public struct Spawner : IComponentData
{
    public Entity Prefab;
    public float2 SpawnPosition1;
    public float2 SpawnPosition2;
    public float2 SpawnPosition3;
    public float2 SpawnPosition4;
    public float NextSpawnTime;
    public float SpawnRate;
}
