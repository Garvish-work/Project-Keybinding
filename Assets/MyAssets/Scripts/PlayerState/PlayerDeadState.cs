using UnityEngine;

public class PlayerDeadState : PlayerBaseState
{
    public PlayerDeadState(InputData _inputData, PlayerAnimationSystem _playerAnimationSystem) : base(_inputData, _playerAnimationSystem)
    {

    }

    public override void Enter()
    {
        base.Enter();
        playerAnimationSystem.MakePlayerDead();
        playerAnimationSystem.SetCrouchValue(false);
    }
    public override void Update()
    {
        if (!inputData.isDead)
        {
            Exit();
            nextState = new PlayerRevivingState(inputData, playerAnimationSystem);  
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
}
