using TopDownCharacterController.Project.Scripts.ECS.ComponentsAndTags;
using Unity.Entities;
using UnityEngine;

namespace TopDownCharacterController.Project.Scripts.ECS.SystemsAndJobs.Raycasting
{
    public partial class RaycastTargetSystem : SystemBase
    {
        private Camera _mainCamera;
        private Plane _rayCastPlane;

        protected override void OnCreate()
        {
            _mainCamera = Camera.main;
            _rayCastPlane = new Plane(Vector3.up, 0);
        }

        protected override void OnUpdate()
        {
            var mousePixelCoords = Input.mousePosition;
            var ray = _mainCamera.ScreenPointToRay(mousePixelCoords);

            // if (Physics.Raycast(ray.origin, ray.direction, out var hit, math.INFINITY ))
            // {
            //     var hitPoint = hit.point;
            //     Debug.DrawLine(ray.origin, hitPoint, Color.red, 0.001f);
            //
            //     Entities.ForEach((ref RaycastTargetComponent raycastTargetComponent) =>
            //     {
            //         raycastTargetComponent.HitPoint = hitPoint;
            //     }).Run();
            // }
            
            if (!_rayCastPlane.Raycast(ray, out var enter))
            {
                return;
            }
            
            var hitPoint = ray.GetPoint(enter);
            hitPoint.y = 0;
            
            Debug.DrawLine(ray.origin, hitPoint, Color.red, 0.001f);
            
            Entities.ForEach((ref RaycastTargetComponent raycastTargetComponent) =>
            {
                raycastTargetComponent.HitPoint = hitPoint;
            }).Run();
        }
    }
}