using UnityEngine;

public class PlayerPunchState : PlayerBaseState
{
    float punchTimer = 0;
    public PlayerPunchState(InputData _inputData, PlayerAnimationSystem _playerAnimationSystem) : base(_inputData, _playerAnimationSystem)
    {
        Debug.Log("Player entered punch state");
    }

    public override void Enter()
    {
        base.Enter();
        punchTimer = 0;
        inputData.inAction = true;

        playerAnimationSystem.TriggerPunch();
    }

    public override void Update()
    {
        punchTimer += Time.deltaTime;

        if (punchTimer > inputData.punchDuration) 
        {
            Exit();
            nextState = new PlayerIdleState(inputData, playerAnimationSystem);
        }
    }

    public override void Exit()
    {
        base.Exit();
        inputData.inAction = false;
        inputData.isPunching = false;
    }
}
