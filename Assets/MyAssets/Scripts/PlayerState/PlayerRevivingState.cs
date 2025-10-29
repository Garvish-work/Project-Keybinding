using UnityEngine;

public class PlayerRevivingState : PlayerBaseState
{
    float reviveTimer = 0;
    public PlayerRevivingState(InputData _inputData, PlayerAnimationSystem _playerAnimationSystem) : base(_inputData, _playerAnimationSystem)
    {

    }

    public override void Enter()
    {
        base.Enter();
        playerAnimationSystem.RevivePlayer();

        ActionHandler.OnPlayerRevive?.Invoke();
        inputData.isDead = false;
        
    }
    public override void Update()
    {
        reviveTimer += Time.deltaTime;

        if (reviveTimer > inputData.reviveDuration)
        {
            Exit();
            nextState = new PlayerIdleState(inputData, playerAnimationSystem);
        }
    }
    public override void Exit()
    {
        base.Exit();
        inputData.inAction = false;
        inputData.isCrouchableAction = true;
        inputData.isCrouching = false;
        inputData.isAiming = false;
        inputData.isJumping = false;
        inputData.isKicking = false;
        inputData.isPunching = false;
        inputData.isReloading = false;

        inputData.playerHealth = inputData.playerMaxHealth;
    }
}
