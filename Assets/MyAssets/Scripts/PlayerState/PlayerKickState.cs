using UnityEngine;

public class PlayerKickState : PlayerBaseState
{
    float kickDuration = 0;
    public PlayerKickState(InputData _inputData, PlayerAnimationSystem _playerAnimationSystem) : base(_inputData, _playerAnimationSystem)
    {
        Debug.Log("Player entered idle state");
    }

    public override void Enter()
    {
        base.Enter();
        inputData.inAction = true;
        inputData.isCrouchableAction = false;

        playerAnimationSystem.TriggerKick();
        kickDuration = 0;
    }

    public override void Update()
    {
        kickDuration += Time.deltaTime;

        if (kickDuration >= inputData.jumpDuration)
        {
            Exit();
            nextState = new PlayerIdleState(inputData, playerAnimationSystem);
        }
        if (inputData.isDead)
        {
            Exit();
            nextState = new PlayerDeadState(inputData, playerAnimationSystem);
        }
    }

    public override void Exit()
    {
        base.Exit();
        inputData.inAction = false;
        inputData.isKicking = false;
        inputData.isCrouchableAction = true;
    }
}
