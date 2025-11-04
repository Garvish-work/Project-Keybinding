using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameplayUiSystem : MonoBehaviour
{
    [SerializeField] private InputData inputData;
    [SerializeField] private Image gethitBar;

    [Header ("Health ui")]
    [SerializeField] private Image healthBar;
    [SerializeField] private TMP_Text healthText;

    float hitTimer = 0;
    float timerMultiplier = 0.5f;
    float hitDuration = 1;
    bool gettinghit = false;

    private void OnEnable()
    {
        ActionHandler.OnPlayerDead += PlayerDead;
        ActionHandler.UpdateHealthUi += UpdateHealthUi;
    }
    private void OnDisable()
    {
        ActionHandler.OnPlayerDead -= PlayerDead;
        ActionHandler.UpdateHealthUi -= UpdateHealthUi;
    }

    private void PlayerDead()
    {
        gettinghit = false;
        StopCoroutine(nameof(StartHitTimer));
    }

    public void B_GetHitButton()
    {
        gettinghit = !gettinghit;

        if (gettinghit) StartCoroutine(nameof(StartHitTimer));
        else StopCoroutine(nameof(StartHitTimer));
    }

    private IEnumerator StartHitTimer()
    {
        while (true)
        {
            if (hitTimer < hitDuration) hitTimer += Time.deltaTime * timerMultiplier;
            else
            {
                hitTimer = 0;
                ActionHandler.OnPlayerGetHit?.Invoke(33); 
            }

            gethitBar.fillAmount = hitTimer;
            yield return null;  
        }
    }

    private void UpdateHealthUi(int healthCount)
    { 
        healthText.text = healthCount.ToString();
        healthBar.fillAmount = Mathf.InverseLerp(0, inputData.playerMaxHealth, healthCount);
    }
}