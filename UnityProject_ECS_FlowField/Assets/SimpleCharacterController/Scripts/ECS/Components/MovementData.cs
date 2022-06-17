using System;
using Unity.Entities;
using Unity.Mathematics;

namespace SimpleCharacterController.Scripts.ECS.Components
{
    [Serializable]
    public struct MovementData : IComponentData
    {
        public float movementSpeed;
        public float3 movementDirection;
    }
}
