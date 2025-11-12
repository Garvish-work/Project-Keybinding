using UnityEngine;

[CreateAssetMenu (fileName = "Weapon data", menuName = "Scriptable/Weapon data")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public WeaponID weaponId;
    public AmmoType ammoType;
    public Sprite weaponIcon;

    [Space]
    public int ammoAvailable;
    public int ammoCapacity;
    public bool isReloadable = true;
}
