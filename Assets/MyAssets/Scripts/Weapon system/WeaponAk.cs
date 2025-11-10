using UnityEngine;

public class WeaponAk : WeaponBehaviour
{
    [SerializeField] private InputData inputData;
    [SerializeField] private WeaponData weaponData;
    public override void Fire()
    {
        if (weaponData.weaponBulletCount <= 0) return;

        weaponData.weaponBulletCount--;
        ActionHandler.OnWeaponFire?.Invoke(weaponData);
    }

    public override WeaponData GetWeaponData()
    {
        return weaponData;
    }

    public override void Reload()
    {
        weaponData.weaponBulletCount = weaponData.weaponAmmoCapacity;
    }
}
