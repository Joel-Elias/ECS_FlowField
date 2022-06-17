using SimpleCharacterController.Scripts.ECS.Components;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

// ReSharper disable once PartialTypeWithSinglePart
namespace SimpleCharacterController.Scripts.ECS.Systems.Movement
{
    public partial class MovementInputSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var (forward, right) = GetCameraDirections();
            var movementInput = GetMovementInput();
            
            Entities.ForEach((ref MovementData movementData) =>
            {
                movementData.movementDirection = CalculateDesiredMoveDirection(forward, right, movementInput);
            }).Schedule();
        }

        private static (float3, float3) GetCameraDirections()
        {
            var camera = Camera.main;

            if (camera == null)
            {
                Debug.LogError("Camera.main is null");

                return (float3.zero, float3.zero);
            }
            
            var transform = camera.transform;
            var forward = transform.forward;
            var right = transform.right;
            forward.y = 0f;
            right.y = 0f;
            forward.Normalize();
            right.Normalize();

            return (forward, right);
        }

        private static float2 GetMovementInput()
        {
            return new float2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }

        private static float3 CalculateDesiredMoveDirection(float3 forward, float3 right, float2 movementInput)
        {
            var desiredMoveDirection = forward * movementInput.y + right * movementInput.x;
            desiredMoveDirection.y = 0;

            return desiredMoveDirection;
        }
        
    }
}