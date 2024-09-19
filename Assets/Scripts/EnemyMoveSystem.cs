using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public partial struct EnemyMoveSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        foreach ((RefRW<LocalTransform> localTransform, RefRO<EnemyComponent> enemyComponent) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<EnemyComponent>>())
        {
            float3 forwardDirection = new float3(0, -1, 0);
            float3 newPosition = localTransform.ValueRO.Position + forwardDirection * enemyComponent.ValueRO.speed * SystemAPI.Time.DeltaTime; 
            localTransform.ValueRW.Position = newPosition;
        }
    }
}
