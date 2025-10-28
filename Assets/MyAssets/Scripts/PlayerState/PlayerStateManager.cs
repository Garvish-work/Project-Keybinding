using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public static PlayerStateManager instnace;

    [SerializeField] private InputData inputData;
    [SerializeField] private PlayerAnimationSystem playerAnimationSystem;
    PlayerBaseState playerCurrentState;


    private void Awake()
    {
        instnace = this;
    }

    private void Start()
    {
        playerCurrentState = new PlayerIdleState(inputData, playerAnimationSystem);
    }

    private void Update()
    {
        playerCurrentState = playerCurrentState.Process();
    }
}
