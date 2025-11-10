using UnityEngine;
using System.Collections;

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
        ActionHandler.OnPlayerGetHit += TriggerGetHit;
    }
    private void OnDisable()
    {
        ActionHandler.OnWeaponFire -= WeaponFire;
        ActionHandler.OnPlayerHeal -= TriggerHeal;
        ActionHandler.OnPlayerGetHit -= TriggerGetHit;
    }
    private void WeaponFire(WeaponData _weaponData)
    {
        switch (_weaponData.weaponName)
        {
            case WeaponName.AK46:
                playerAnime.SetTrigger("Shoot");
                break;
        }
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
    private void TriggerGetHit()
    {
        int randomIndex = Random.Range(0, 3);
        playerAnime.SetTrigger("GetHit");
        playerAnime.SetInteger("HitIndex", randomIndex);
    }
    #endregion

    public void Start()
    {
        ActionHandler.OnWeaponChanged(WeaponName.HANDS);
    }

    public void SetCrouchValue(bool value)
    {
        playerAnime.SetBool("isCrouching", value);
    }

    public void MakePlayerDead()
    {
        playerAnime.SetTrigger("isDead");
    }
    public void RevivePlayer()
    {
        playerAnime.SetTrigger("isRevived");
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
    float _value = 0;
    bool coroutineStarted = false;
    public void AimWeapon(bool aimFlag)
    {
        if (aimFlag) _value = 1; else _value = 0;
        if (!coroutineStarted) StartCoroutine(nameof(UpdateAimValue));
    }

    private IEnumerator UpdateAimValue()
    {
        coroutineStarted = true;
        while (aimValue != _value)
        {
            akMainHolder.localScale = Vector4.one * aimValue;   
            aimValue = Mathf.MoveTowards(aimValue, _value, 5 * Time.deltaTime);
            playerAnime.SetLayerWeight(1, aimValue);
            yield return null;  
        }
        coroutineStarted = false;
    }
}
