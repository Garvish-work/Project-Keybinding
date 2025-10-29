using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameplayUiSystem : MonoBehaviour
{
    [SerializeField] private Image gethitBar;

    float hitTimer = 0;
    float timerMultiplier = 0.5f;
    float hitDuration = 1;
    bool gettinghit = false;

    private void OnEnable()
    {
        ActionHandler.OnPlayerDead += PlayerDead;
    }
    private void OnDisable()
    {
        ActionHandler.OnPlayerDead -= PlayerDead;
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
                ActionHandler.OnPlayerGetHit?.Invoke();
            }

            gethitBar.fillAmount = hitTimer;
            yield return null;  
        }

    }
}