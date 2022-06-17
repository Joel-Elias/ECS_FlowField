using TopDownCharacterController.Project.Scripts.ECS.ComponentsAndTags;
using Unity.Entities;
using UnityEngine;

namespace TopDownCharacterController.Project.Scripts.ECS.SystemsAndJobs.PlayerInputDataPointer
{
    public partial class PlayerInputDataPointerStateSystem : SystemBase
    {
        private const string _MainInputName = "Fire1";
        
        protected override void OnCreate()
        {
            RequireSingletonForUpdate<PlayerInputComponent>();
        }

        protected override void OnUpdate()
        {
            var playerInputSingleton = GetSingleton<PlayerInputComponent>();
            var fire1IsDown = Input.GetButtonDown(_MainInputName);
            var fire1IsHold = Input.GetButton(_MainInputName);
            var fire1IsUp = Input.GetButtonUp(_MainInputName);
            
            playerInputSingleton.PointerIsClick = fire1IsDown;
            playerInputSingleton.PointerIsHold = fire1IsHold;
            playerInputSingleton.PointerIsRelease = fire1IsUp;
            
            SetSingleton(playerInputSingleton);
        }
    }
}