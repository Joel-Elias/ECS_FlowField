using SimpleCharacterController.Scripts.ECS.Components;
using Unity.Entities;
using Unity.Transforms;

namespace SimpleCharacterController.Scripts.ECS.Systems.Movement
{
    // ReSharper disable once PartialTypeWithSinglePart
    public partial class MovementSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var deltaTime = Time.DeltaTime;
            
            Entities.ForEach((ref Translation translation, in MovementData movementData) =>
            {
                translation.Value += movementData.movementDirection * movementData.movementSpeed * deltaTime;
            }).Schedule();
        }
    }
}