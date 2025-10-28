using UnityEngine;

public class PlayerBaseState 
{
    public enum EventState
    {
        ENTER, UPDATE, EXIT
    };
    protected EventState eventState;
    protected InputData inputData;
    protected Animator playerAnimator;
    protected PlayerAnimationSystem playerAnimationSystem;

    protected PlayerBaseState nextState;

    public PlayerBaseState(InputData _inputData, PlayerAnimationSystem _playerAnimationSystem)
    {
        inputData = _inputData;
        playerAnimationSystem = _playerAnimationSystem;

        eventState = EventState.ENTER;  
    }

    public virtual void Enter() { eventState = EventState.UPDATE; }
    public virtual void Update() { eventState = EventState.UPDATE; }
    public virtual void Exit() 
    {
        eventState = EventState.EXIT; 
    }

    public PlayerBaseState Process()
    {
        if (eventState == EventState.ENTER) { Enter(); }
        if (eventState == EventState.UPDATE) { Update(); }
        if (eventState == EventState.EXIT)
        {
            Exit();
            return nextState;
        }
        else return this;
    }
}
