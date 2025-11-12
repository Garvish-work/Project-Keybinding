using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameplayUiSystem : MonoBehaviour
{
    WeaponController weaponController;
    Animator weaponIconAnimator;

    [SerializeField] private Image gethitBar;
    [SerializeField] private InputData inputData;

    [Header ("Weapon ui")]
    [SerializeField] private Image weaponIconImage;
    [SerializeField] private TMP_Text weaponNameText;
    [SerializeField] private TMP_Text weaponAmmoText;


    [Header ("Health ui")]
    [SerializeField] private Image healthBar;
    [SerializeField] private TMP_Text healthText;

    float hitTimer = 0;
    float timerMultiplier = 0.5f;
    float hitDuration = 1;
    bool gettinghit = false;

    private void Awake()
    {
        weaponIconAnimator = weaponIconImage.GetComponent<Animator>();
    }

    private void Start()
    {
        weaponController = WeaponController.instance;
    }

    private void OnEnable()
    {
        ActionHandler.OnPlayerDead += PlayerDead;
        ActionHandler.OnNoAmmo += NoAmmo;
        ActionHandler.UpdateHealthUi += UpdateHealthUi;
        ActionHandler.OnUpdateWeaponUi += UpdateWeaponUi;
        ActionHandler.OnWeaponReloadStart += OnReloadStarted;
    }
    private void OnDisable()
    {
        ActionHandler.OnPlayerDead -= PlayerDead;
        ActionHandler.OnNoAmmo -= NoAmmo;
        ActionHandler.UpdateHealthUi -= UpdateHealthUi;
        ActionHandler.OnUpdateWeaponUi -= UpdateWeaponUi;
        ActionHandler.OnWeaponReloadStart -= OnReloadStarted;
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

    private void UpdateWeaponUi(WeaponData _weaponData, UiUpdateType _updateType)
    {
        switch (_updateType)
        {
            case UiUpdateType.FULL:
                weaponIconImage.sprite = _weaponData.weaponIcon;
                switch (_weaponData.ammoType)
                {
                    case AmmoType.FINITY:
                        weaponAmmoText.text = _weaponData.ammoAvailable.ToString("000");
                        weaponAmmoText.fontSize = 15;
                        break;
                    case AmmoType.INFINITY:
                        weaponAmmoText.text = "∞";
                        weaponAmmoText.fontSize = 23;
                        break;
                }

                Debug.Log("Trigger weapon animation");
                weaponIconAnimator.SetTrigger("Change");
                weaponNameText.text = _weaponData.weaponName;
                break;
            case UiUpdateType.WEAPON_AMMO:
                switch (_weaponData.ammoType)
                {
                    case AmmoType.FINITY:
                        weaponAmmoText.text = _weaponData.ammoAvailable.ToString("000");
                        weaponAmmoText.fontSize = 15;
                        break;
                    case AmmoType.INFINITY:
                        weaponAmmoText.text = "∞";
                        weaponAmmoText.fontSize = 23;
                        break;
                }
                break;
        }
    }

    private void OnReloadStarted()
    {
        weaponAmmoText.text = "RELOADING";
    }

    private void NoAmmo()
    {
        weaponIconAnimator.SetTrigger("Shake");
    }
}