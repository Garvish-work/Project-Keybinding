using System.Collections;
using UnityEngine;

public class PlayerAnimationSystem : MonoBehaviour
{
    [SerializeField] private InputData inputData;
    [SerializeField] private Animator playerAnime;

    [Header ("Aiming animation")]
    [SerializeField] private Transform akMainHolder;

    [Header ("Healing animation")]
    [SerializeField] private GameObject healthBoxHolder;

    [Header ("Reloading animation")]
    [SerializeField] private GameObject weaponMag;
    [SerializeField] private GameObject handMag;

    #region LISTENERS
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
    #endregion


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

    public void TriggerKick()
    {
        playerAnime.SetTrigger("Kick");
    }

    public void TriggerReload()
    {
        StartCoroutine(nameof(ReloadAnimation));
    }
    private IEnumerator ReloadAnimation()
    {
        playerAnime.SetTrigger("Reload");
        yield return new WaitForSeconds(0.5f);

        handMag.SetActive(true);
        weaponMag.SetActive(false);
        yield return new WaitForSeconds(1.2f);

        handMag.SetActive(false);
        weaponMag.SetActive(true);
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
