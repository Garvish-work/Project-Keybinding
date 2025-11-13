using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    [SerializeField] private InputData inputData;
    public void OnEnable()
    {
        ActionHandler.OnPlayerGetHit += PlayerGotHit;
        ActionHandler.OnPlayerRevive += SetPlayerReviveHealth;
        ActionHandler.ChangePlayerHealth += SetPlayerHealth;
    }
    private void OnDisable()
    {
        ActionHandler.OnPlayerGetHit -= PlayerGotHit;
        ActionHandler.OnPlayerRevive -= SetPlayerReviveHealth;
        ActionHandler.ChangePlayerHealth -= SetPlayerHealth;
    }

    private void Start()
    {
        SetPlayerMaxHealth();
    }

    private void SetPlayerMaxHealth()
    {
        inputData.playerHealth = inputData.playerMaxHealth;
        ActionHandler.UpdateHealthUi?.Invoke(inputData.playerHealth);
    }

    private void SetPlayerReviveHealth()
    {
        SetPlayerHealth(30, "add");
    }

    private void PlayerGotHit(int hitValue)
    {
        ActionHandler.OnRequestSoundEffect(SoundEffects.GET_PUNCHED);
        SetPlayerHealth(hitValue, "remove");
    }

    private void SetPlayerHealth(int hitValue, string _type = "add")
    {
        switch (_type)
        {
            case "add":
                inputData.playerHealth = Mathf.Min(inputData.playerMaxHealth, inputData.playerHealth += hitValue);
                break;
            case "remove":
                inputData.playerHealth = Mathf.Max(0, inputData.playerHealth -= hitValue);
                
                // check if player is dead or not
                if (inputData.playerHealth <= 0)
                {
                    inputData.isDead = true;
                    ActionHandler.OnPlayerDead?.Invoke();
                }
                break;
        }
        ActionHandler.UpdateHealthUi?.Invoke(inputData.playerHealth);
    }
}
