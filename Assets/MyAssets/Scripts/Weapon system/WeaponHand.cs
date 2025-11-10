using UnityEngine;

public class WeaponHand : WeaponBehaviour
{
    [SerializeField] private InputData inputData;
    [SerializeField] private WeaponData weaponData;
    public override void Reload()
    {
        
    }

    public override WeaponData GetWeaponData()
    {
        return weaponData;
    }

    public override void Fire()
    {
        inputData.isPunching = true;    
    }
}
