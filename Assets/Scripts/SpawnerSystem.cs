using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial struct SpawnerSystem : ISystem   
{
    public void OnCreate(ref SystemState state)
    {
    }

    public void OnDestroy(ref SystemState state)
    {
    }

    public void OnUpdate(ref SystemState state)
    {
        foreach (RefRW<Spawner> spawner in SystemAPI.Query<RefRW<Spawner>>())
        {
            if (spawner.ValueRO.NextSpawnTime < SystemAPI.Time.ElapsedTime)
            {
                SpawnEntityAtPosition(ref state, spawner.ValueRO.Prefab, spawner.ValueRO.SpawnPosition1);
                SpawnEntityAtPosition(ref state, spawner.ValueRO.Prefab, spawner.ValueRO.SpawnPosition2);
                SpawnEntityAtPosition(ref state, spawner.ValueRO.Prefab, spawner.ValueRO.SpawnPosition3);
                SpawnEntityAtPosition(ref state, spawner.ValueRO.Prefab, spawner.ValueRO.SpawnPosition4);
                
                spawner.ValueRW.NextSpawnTime = (float)SystemAPI.Time.ElapsedTime + spawner.ValueRO.SpawnRate;
            }
        }
    }
    private void SpawnEntityAtPosition(ref SystemState state, Entity prefab, float2 position)
    {
        Entity newEntity = state.EntityManager.Instantiate(prefab);
        float3 pos = new float3(position.x, position.y, 0);
        state.EntityManager.SetComponentData(newEntity, LocalTransform.FromPosition(pos));
    }
}