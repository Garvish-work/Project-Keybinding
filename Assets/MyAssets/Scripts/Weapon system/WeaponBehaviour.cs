using UnityEngine;

public interface IShootable
{
    public void Fire();
    public void Reload();
}

public abstract class WeaponBehaviour : MonoBehaviour
{
    public abstract void Fire();
    public abstract void Reload();  
    public abstract WeaponData GetWeaponData();  
}