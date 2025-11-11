using UnityEngine;

public abstract class WeaponBehaviour : MonoBehaviour
{
    public abstract void Fire();

    public abstract void Reload();

    public abstract WeaponData GetWeaponData();
}
