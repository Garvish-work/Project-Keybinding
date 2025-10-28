using System.Collections;
using UnityEngine;

public class PlayerAnimationSystem : MonoBehaviour
{
    [SerializeField] private InputData inputData;
    [SerializeField] private Animator playerAnime;
    [SerializeField] private Transform akMainHolder;
    [SerializeField] private GameObject healthBoxHolder;

    private void OnEnable()
    {
        ActionHandler.OnWeaponFire += WeaponFire;
        ActionHandler.OnPlayerHeal += TriggerHeal;
    }

    private void OnDisable()
    {
        ActionHandler.OnWeaponFire -= WeaponFire;
        ActionHandler.OnPlayerHeal -= TriggerHeal;
    }

    private void WeaponFire()
    {
        playerAnime.SetTrigger("Shoot");
    }

    public void SetCrouchValue(bool value)
    {
        playerAnime.SetBool("isCrouching", value);
    }

    public void TriggerJump()
    {
        playerAnime.SetTrigger("Jump");
    }

    public void TriggerPunch()
    {
        playerAnime.SetTrigger("Punch");
    }

    public void TriggerHeal()
    {
        StartCoroutine(nameof(AppleHealing));
    }

    private IEnumerator AppleHealing()
    {
        float healTimer = 0;
        inputData.inAction = true;

        playerAnime.SetTrigger("Heal");
        healthBoxHolder.SetActive(true);

        while (healTimer < inputData.healDuration)
        {
            healTimer += Time.deltaTime;
            yield return null;
        }
        inputData.inAction = false;
        healthBoxHolder.SetActive(false);
    }

    public void TriggerKick()
    {
        playerAnime.SetTrigger("Kick");
    }

    float aimValue = 0;
    public void AimWeapon(bool aimFlag)
    {
        StartCoroutine(nameof(UpdateAimValue), aimFlag ? 1 : 0);
    }

    private IEnumerator UpdateAimValue(float desireValue)
    {
        while (aimValue != desireValue)
        {
            akMainHolder.localScale = Vector4.one * aimValue;   
            aimValue = Mathf.MoveTowards(aimValue, desireValue, 5 * Time.deltaTime);
            playerAnime.SetLayerWeight(1, aimValue);
            yield return null;  
        }
    }
}
