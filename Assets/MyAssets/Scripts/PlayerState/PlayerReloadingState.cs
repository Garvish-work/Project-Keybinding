using UnityEngine;

public class PlayerReloadingState : PlayerBaseState
{
    float reloadTimer = 0f;
    public PlayerReloadingState(InputData _inputData, PlayerAnimationSystem _playerAnimationSystem) : base(_inputData, _playerAnimationSystem)
    {
        Debug.Log("Player entered idle state");
    }

    public override void Enter()
    {
        base.Enter();
        inputData.inAction = true;
        inputData.isCrouchableAction = true;

        ActionHandler.OnReloadStarted?.Invoke();
        playerAnimationSystem.TriggerReload();
        reloadTimer = 0;
    }

    public override void Update()
    {
        reloadTimer += Time.deltaTime;
        playerAnimationSystem.SetCrouchValue(inputData.isCrouching);

        if (reloadTimer >= inputData.reloadDuration)
        {
            Exit();
            ActionHandler.OnReloadComplete?.Invoke();
            nextState = new PlayerAimState(inputData, playerAnimationSystem);
        }
        if (inputData.isDead)
        {
            Exit();
            ActionHandler.OnWeaponChanged(WeaponName.HANDS);
            playerAnimationSystem.AimWeapon(false);
            nextState = new PlayerDeadState(inputData, playerAnimationSystem);
        }
    }

    public override void Exit()
    {
        base.Exit();
        inputData.inAction = false;
        inputData.isReloading = false;
    }
}
