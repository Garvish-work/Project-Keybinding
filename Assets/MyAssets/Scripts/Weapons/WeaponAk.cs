using UnityEngine;

public class WeaponAk : WeaponBehaviour
{
    [SerializeField] private InputData inputData ;
    [SerializeField] private WeaponData weaponData;

    public override WeaponData GetWeaponData()
    {
        return weaponData;  
    }

    public override void Reload()
    {
        inputData.isReloading = true;   
    }

    public override void Fire()
    {
        weaponData.ammoAvailable--;
        ActionHandler.OnUpdateWeaponUi(weaponData, UiUpdateType.WEAPON_AMMO); 
    }
}
