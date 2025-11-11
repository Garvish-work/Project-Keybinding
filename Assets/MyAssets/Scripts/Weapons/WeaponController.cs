using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public static WeaponController instance;

    [SerializeField] private WeaponBehaviour currentWeapon;

    [Space]
    [SerializeField] private WeaponBehaviour weaponHand;
    [SerializeField] private WeaponBehaviour weaponAk;

    private void OnEnable()
    {
        ActionHandler.OnWeaponFire += WeaponFire;
        ActionHandler.OnWeaponChange += WeaponChange;
    }

    private void OnDisable()
    {
        ActionHandler.OnWeaponChange -= WeaponChange;
        ActionHandler.OnWeaponFire -= WeaponFire;
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentWeapon = weaponHand;
    }

    private void WeaponFire()
    {
        currentWeapon.Fire();
        ActionHandler.CatchWeaponFire?.Invoke(currentWeapon.GetWeaponData().weaponId);
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
        ActionHandler.OnUpdateWeaponUi?.Invoke(currentWeapon.GetWeaponData());
    }

    public WeaponData GetCurrentWeaponData()
    {
        return currentWeapon.GetWeaponData();
    }
}