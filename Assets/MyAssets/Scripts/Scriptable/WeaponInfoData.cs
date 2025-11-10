using UnityEngine;

[CreateAssetMenu (fileName = "Weapon info data", menuName = "Scriptable/Weapon info data")]
public class WeaponInfoData : ScriptableObject
{
    public WeaponBehaviour currentWeapon;
    public int healthPotionCount = 5;
    public int healthPotionMaxCount = 5;
    public float healthPotionFillDuration = 5;
}
