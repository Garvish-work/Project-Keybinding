using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public static WeaponController instance;

    WeaponData currentWeaponData;
    [SerializeField] private WeaponBehaviour currentWeapon;

    [Space]
    [SerializeField] private WeaponBehaviour weaponHand;
    [SerializeField] private WeaponBehaviour weaponAk;

    private void OnEnable()
    {
        ActionHandler.OnWeaponFire += WeaponFire;
        ActionHandler.OnWeaponChange += WeaponChange;
        ActionHandler.OnWeaponReloadStart += WeaponReloadStart;
        ActionHandler.OnWeaponReloadCompleted += WeaponReloadCompleted;
    }

    private void OnDisable()
    {
        ActionHandler.OnWeaponChange -= WeaponChange;
        ActionHandler.OnWeaponFire -= WeaponFire;
        ActionHandler.OnWeaponReloadStart -= WeaponReloadStart;
        ActionHandler.OnWeaponReloadCompleted -= WeaponReloadCompleted;
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        WeaponChange(WeaponID.HANDS);
    }

    private void WeaponFire()
    {
        if (currentWeaponData.ammoAvailable <= 0)
        {
            ActionHandler.OnRequestSoundEffect?.Invoke(SoundEffects.NO_AMMO);
            ActionHandler.OnNoAmmo?.Invoke();
            return;
        }

        currentWeapon.Fire();
        ActionHandler.CatchWeaponFire?.Invoke(currentWeaponData.weaponId);
    }

    private void WeaponReloadStart()
    {
        currentWeapon.Reload();
    }

    private void WeaponChange (WeaponID _weaponId)
    {
        switch (_weaponId)
        {
            case WeaponID.HANDS:
                currentWeapon = weaponHand;
                break;
            case WeaponID.AK46:
                currentWeapon = weaponAk;
                break;
        }
        currentWeaponData = currentWeapon.GetWeaponData();
        ActionHandler.OnUpdateWeaponUi?.Invoke(currentWeaponData, UiUpdateType.FULL);
    }

    public WeaponData GetCurrentWeaponData()
    {
        return currentWeaponData;
    }

    private void WeaponReloadCompleted()
    {
        currentWeaponData.ammoAvailable = currentWeaponData.ammoCapacity;
        ActionHandler.OnUpdateWeaponUi(currentWeaponData, UiUpdateType.FULL);
    }
}