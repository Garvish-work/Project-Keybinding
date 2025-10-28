using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    float jumpTimer = 0;
    public PlayerJumpState(InputData _inputData, PlayerAnimationSystem _playerAnimationSystem) : base(_inputData, _playerAnimationSystem)
    {
        Debug.Log("Player entered idle state");
    }

    public override void Enter()
    {
        base.Enter();
        inputData.inAction = true;
        playerAnimationSystem.TriggerJump();
        jumpTimer = 0;

    }

    public override void Update()
    {
        jumpTimer += Time.deltaTime;

        if (jumpTimer >= inputData.jumpDuration)
        {

            Exit();
            nextState = new PlayerIdleState(inputData, playerAnimationSystem);
        }
    }

    public override void Exit()
    {
        base.Exit();

        inputData.inAction = false;
        inputData.isJumping = false;
    }
}
