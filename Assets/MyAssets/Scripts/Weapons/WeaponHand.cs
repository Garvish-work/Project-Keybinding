using UnityEngine;

public class WeaponHand : WeaponBehaviour
{
    [SerializeField] private InputData inputData;
    [SerializeField] private WeaponData weaponData;

    public override WeaponData GetWeaponData()
    {
        return weaponData;
    }

    public override void Reload()
    {

    }

    public override void Fire()
    {
        inputData.isPunching = true;
        ActionHandler.OnRequestSoundEffect(weaponData.weaponFireSfx);
    }
}
