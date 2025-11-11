using UnityEngine;

public class GameplayVfxSystem : MonoBehaviour
{
    [SerializeField] private ParticleSystem healingVfx;
    [SerializeField] private ParticleSystem akVfx;
    private void OnEnable()
    {
        ActionHandler.OnPlayerRevive += PlayerRevived;
        ActionHandler.CatchWeaponFire += muzzleFlash;
    }
    private void OnDisable()
    {
        ActionHandler.OnPlayerRevive -= PlayerRevived;
        ActionHandler.CatchWeaponFire -= muzzleFlash;
    }

    private void PlayerRevived()
    {
        healingVfx.Play(true);
    }

    private void muzzleFlash(WeaponID _weaponId)
    {
        switch (_weaponId)
        {
            case WeaponID.AK46:
                akVfx.Play(true);
                break;
        }
    }
}
