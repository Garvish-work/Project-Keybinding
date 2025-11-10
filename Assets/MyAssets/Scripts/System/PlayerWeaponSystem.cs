using UnityEngine;

public class PlayerWeaponSystem : MonoBehaviour
{
    [SerializeField] private WeaponInfoData weaponInfoDatas;
    [SerializeField] private WeaponBehaviour weaponAk;
    [SerializeField] private WeaponBehaviour weaponHand;

    private void OnEnable()
    {
        ActionHandler.OnPlayerHitFire += WeaponFire;
        ActionHandler.OnWeaponChanged += WeaponChange;
        ActionHandler.OnReloadComplete += WeaponReload;
    }

    private void OnDisable()
    {
        ActionHandler.OnPlayerHitFire -= WeaponFire;
        ActionHandler.OnWeaponChanged -= WeaponChange;
        ActionHandler.OnReloadComplete -= WeaponReload;
    }

    private void Awake()
    {
        WeaponChange(WeaponName.HANDS);
    }

    private void WeaponFire()
    {
        weaponInfoDatas.currentWeapon.Fire();
    }

    private void WeaponReload()
    {
        weaponInfoDatas.currentWeapon.Reload();
    }

    private void WeaponChange(WeaponName _weaponName)
    {
        switch (_weaponName)
        {
            case WeaponName.HANDS:
                weaponInfoDatas.currentWeapon = weaponHand;
                ActionHandler.OnChangeWeaponUi?.Invoke();
                break;
            case WeaponName.AK46:
                weaponInfoDatas.currentWeapon = weaponAk;
                ActionHandler.OnChangeWeaponUi?.Invoke();
                break;
        }
    }
}