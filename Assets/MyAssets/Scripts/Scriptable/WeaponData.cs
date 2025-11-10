using UnityEngine;

[CreateAssetMenu(fileName = "Weapon data", menuName = "Scriptable/Weapon data")]
public class WeaponData : ScriptableObject
{
    public string weaponDefination;
    public WeaponName weaponName;
    public AmmoType ammoType;
    public WeaponType weaponType;

    [Space]
    public Sprite weaponIcon;

    [Space]
    public int weaponBulletCount = 30;
    public int weaponAmmoCapacity = 30;
    public float fireRate = 0.2f;
}