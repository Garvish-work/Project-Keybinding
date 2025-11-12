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
        inputData.isCrouchableAction = true;

        ActionHandler.OnWeaponChange(WeaponID.AK46);
    }

    public override void Update()
    {
        playerAnimationSystem.SetCrouchValue(inputData.isCrouching);
        
        if (!inputData.isAiming) 
        {
            Exit();

            playerAnimationSystem.AimWeapon(false);
            ActionHandler.OnWeaponChange(WeaponID.HANDS);

            nextState = new PlayerIdleState(inputData, playerAnimationSystem);
        }
        if (inputData.isReloading)
        {
            Exit();
            nextState = new PlayerReloadingState(inputData, playerAnimationSystem);
        }
        if (inputData.isDead)
        {
            Exit();
            playerAnimationSystem.AimWeapon(false);
            ActionHandler.OnWeaponChange(WeaponID.HANDS);

            nextState = new PlayerDeadState(inputData, playerAnimationSystem);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
