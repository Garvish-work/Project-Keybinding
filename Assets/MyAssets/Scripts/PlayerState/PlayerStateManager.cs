using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public static PlayerStateManager instnace;

    [SerializeField] private InputData inputData;
    [SerializeField] private PlayerAnimationSystem playerAnimationSystem;
    PlayerBaseState playerCurrentState;

    private void OnEnable()
    {
        ActionHandler.OnPlayerGetHit += PlayerGotHit;   
    }

    private void OnDisable()
    {
        ActionHandler.OnPlayerGetHit -= PlayerGotHit;   
    }

    private void Awake()
    {
        instnace = this;
    }

    private void Start()
    {
        inputData.playerHealth = inputData.playerMaxHealth;
        playerCurrentState = new PlayerIdleState(inputData, playerAnimationSystem);
    }

    private void Update()
    {
        playerCurrentState = playerCurrentState.Process();
    }

    private void PlayerGotHit()
    {
        inputData.playerHealth--;
        if (inputData.playerHealth <= 0 ) 
        {
            inputData.isDead = true;
            ActionHandler.OnPlayerDead?.Invoke();
        }
    }
}
