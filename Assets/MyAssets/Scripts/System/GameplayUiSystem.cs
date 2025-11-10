<<<<<<< Updated upstream
=======
﻿using TMPro;
>>>>>>> Stashed changes
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameplayUiSystem : MonoBehaviour
{
<<<<<<< Updated upstream
    [SerializeField] private Image gethitBar;

=======
    [SerializeField] private WeaponInfoData weaponInfoData;
    [SerializeField] private InputData inputData;
    [SerializeField] private Image gethitBar;

    [Header ("Weapon ui")]
    [SerializeField] private Image weaponImage;
    [SerializeField] private TMP_Text weaponName;
    [SerializeField] private TMP_Text weaponAmmo;

    [Header ("Health ui")]
    [SerializeField] private Image healthPotionfillImage;
    [SerializeField] private Image healthBar;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text healthPotionCountText;

>>>>>>> Stashed changes
    float hitTimer = 0;
    float timerMultiplier = 0.5f;
    float hitDuration = 1;
    bool gettinghit = false;

    private void OnEnable()
    {
        ActionHandler.OnPlayerDead += PlayerDead;
<<<<<<< Updated upstream
=======
        ActionHandler.UpdateHealthUi += UpdateHealthUi;
        ActionHandler.OnChangeWeaponUi += UpdateWeaponWheel;
        ActionHandler.OnWeaponFire += UpdateAmmoCount;

        ActionHandler.OnPlayerHeal += PlayerHealed;

        ActionHandler.OnReloadStarted += ReloadingStarted;
        ActionHandler.OnReloadStarted += ReloadingStarted;
>>>>>>> Stashed changes
    }
    private void OnDisable()
    {
        ActionHandler.OnPlayerDead -= PlayerDead;
<<<<<<< Updated upstream
=======
        ActionHandler.UpdateHealthUi -= UpdateHealthUi;
        ActionHandler.OnChangeWeaponUi -= UpdateWeaponWheel;
        ActionHandler.OnWeaponFire -= UpdateAmmoCount;

        ActionHandler.OnPlayerHeal -= PlayerHealed;

        ActionHandler.OnReloadComplete -= ReloadComplete;
        ActionHandler.OnReloadComplete -= ReloadComplete;
    }

    private void Start()
    {
        FillHealthPotionBar();
>>>>>>> Stashed changes
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


    private void UpdateWeaponWheel()
    {
        WeaponData _weaponData = weaponInfoData.currentWeapon.GetWeaponData();

        weaponImage.sprite = _weaponData.weaponIcon;
        weaponName.text = _weaponData.weaponDefination;
        if (_weaponData.ammoType == AmmoType.INFINITE)
        {
            weaponAmmo.text = "∞";
            weaponAmmo.fontSize = 20;
        }
        else
        {
            weaponAmmo.text = _weaponData.weaponBulletCount.ToString("000");
            weaponAmmo.fontSize = 13;
        }
    }

    private void UpdateAmmoCount(WeaponData _weaponData)
    {
        weaponAmmo.text = _weaponData.weaponBulletCount.ToString("000");
    }

    private void ReloadingStarted()
    {
        weaponAmmo.text = "RELOADING";
    }

    private void ReloadComplete()
    {
        WeaponData _weaponData = weaponInfoData.currentWeapon.GetWeaponData();
        UpdateAmmoCount(_weaponData);
    }

    private void PlayerHealed()
    {
        weaponInfoData.healthPotionCount--;
        healthPotionCountText.text = weaponInfoData.healthPotionCount.ToString("00");
        FillHealthPotionBar();
    }

    private void FillHealthPotionBar()
    {
        healthPotionCountText.text = weaponInfoData.healthPotionCount.ToString("00");
        if (!healthBarCoroutineStarted) StartCoroutine(nameof(FillHealthBar));
    }

    bool healthBarCoroutineStarted = false;
    private IEnumerator FillHealthBar()
    {
        healthBarCoroutineStarted = true;
        float timer = 0;

        healthPotionfillImage.gameObject.SetActive(true);
        while(weaponInfoData.healthPotionCount != weaponInfoData.healthPotionMaxCount)
        {
            if (timer < weaponInfoData.healthPotionFillDuration)
            {
                timer += Time.deltaTime;
                healthPotionfillImage.fillAmount = Mathf.InverseLerp(0, weaponInfoData.healthPotionFillDuration, timer);
            }
            else
            {
                timer = 0;
                weaponInfoData.healthPotionCount++;
                healthPotionCountText.text = weaponInfoData.healthPotionCount.ToString("00");
            }
            yield return null;
        }

        healthPotionfillImage.gameObject.SetActive(false);
        healthBarCoroutineStarted = false;
    }
}