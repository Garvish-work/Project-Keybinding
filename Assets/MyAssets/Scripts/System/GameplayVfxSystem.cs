using UnityEngine;

public class GameplayVfxSystem : MonoBehaviour
{
    [SerializeField] private ParticleSystem healingVfx;
    [SerializeField] private ParticleSystem akVfx;
    private void OnEnable()
    {
        ActionHandler.OnPlayerRevive += PlayerRevived;
        ActionHandler.OnWeaponFire += muzzleFlash;
    }
    private void OnDisable()
    {
        ActionHandler.OnPlayerRevive -= PlayerRevived;
        ActionHandler.OnWeaponFire -= muzzleFlash;
    }

    private void PlayerRevived()
    {
        healingVfx.Play(true);
    }

    private void muzzleFlash(WeaponData _weaponData)
    {
        switch (_weaponData.weaponName)
        {
            case WeaponName.AK46:
                akVfx.Play(true);
                break;
        }
    }
}
