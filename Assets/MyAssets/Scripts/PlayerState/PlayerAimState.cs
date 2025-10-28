using UnityEngine;

public class PlayerAimState : PlayerBaseState
{
    public PlayerAimState(InputData _inputData, PlayerAnimationSystem _playerAnimationSystem) : base(_inputData, _playerAnimationSystem)
    {
        Debug.Log("Player entered idle state");
    }

    public override void Enter()
    {
        base.Enter();
        playerAnimationSystem.AimWeapon(true);
    }

    public override void Update()
    {
        playerAnimationSystem.SetCrouchValue(inputData.isCrouching);
        
        if (!inputData.isAiming) 
        {
            playerAnimationSystem.AimWeapon(false);
            nextState = new PlayerIdleState(inputData, playerAnimationSystem);
            Exit();
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
