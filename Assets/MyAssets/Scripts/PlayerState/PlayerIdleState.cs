using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(InputData _inputData, PlayerAnimationSystem _playerAnimationSystem) : base(_inputData, _playerAnimationSystem)
    {
        Debug.Log("Player entered idle state");
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        playerAnimationSystem.SetCrouchValue(inputData.isCrouching);

        if (inputData.isJumping)
        {
            inputData.isCrouching = false;
            playerAnimationSystem.SetCrouchValue(inputData.isCrouching);

            Exit();
            nextState = new PlayerJumpState(inputData, playerAnimationSystem);
        }

        if (inputData.isKicking)
        {
            inputData.isCrouching = false;
            playerAnimationSystem.SetCrouchValue(inputData.isCrouching);

            Exit();
            nextState = new PlayerKickState(inputData, playerAnimationSystem);
        }


        if (inputData.isPunching)
        {
            inputData.isCrouching = false;
            playerAnimationSystem.SetCrouchValue(inputData.isCrouching);

            Exit();
            nextState = new PlayerPunchState(inputData, playerAnimationSystem);
        }

        if (inputData.isAiming)
        {
            Exit();
            nextState = new PlayerAimState(inputData, playerAnimationSystem);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
