using SimpleCharacterController.Scripts.ECS.Components;
using Unity.Entities;
using UnityEngine;

namespace SimpleCharacterController.Scripts.ECS.Authoring
{
    public class PlayerAuthoring : MonoBehaviour, IConvertGameObjectToEntity
    {
        [SerializeField] private float movementSpeed;

        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponentData(entity, new MovementData
            {
                movementSpeed = movementSpeed
            });
        }
    }
}
