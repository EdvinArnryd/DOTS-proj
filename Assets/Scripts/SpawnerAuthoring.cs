using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class SpawnerAuthoring : MonoBehaviour
{
    public GameObject Prefab;
    public float SpawnRate;

    class SpawnerBaker : Baker<SpawnerAuthoring>
    {
        public override void Bake(SpawnerAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(entity, new Spawner
            {
                Prefab = GetEntity(authoring.Prefab, TransformUsageFlags.Dynamic),
                SpawnPosition1 = new float2(-8,8),
                SpawnPosition2 = new float2(-3,6),
                SpawnPosition3 = new float2(3,6),
                SpawnPosition4 = new float2(8,7),
                NextSpawnTime = 0,
                SpawnRate = authoring.SpawnRate
            });
        }
    }
}
