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
        ActionHandler.OnWeaponChanged(WeaponName.AK46);
        playerAnimationSystem.AimWeapon(true);
        inputData.isCrouchableAction = true;
    }

    public override void Update()
    {
        playerAnimationSystem.SetCrouchValue(inputData.isCrouching);
        
        if (!inputData.isAiming) 
        {
            ActionHandler.OnWeaponChanged(WeaponName.HANDS);
            playerAnimationSystem.AimWeapon(false);
            nextState = new PlayerIdleState(inputData, playerAnimationSystem);
            Exit();
        }
        if (inputData.isReloading)
        {
            ActionHandler.OnWeaponChanged(WeaponName.AK46);
            nextState = new PlayerReloadingState(inputData, playerAnimationSystem);
            Exit();
        }
        if (inputData.isDead)
        {
            ActionHandler.OnWeaponChanged(WeaponName.HANDS);
            Exit();
            playerAnimationSystem.AimWeapon(false);
            nextState = new PlayerDeadState(inputData, playerAnimationSystem);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
