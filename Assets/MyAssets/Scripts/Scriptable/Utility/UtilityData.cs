using UnityEngine;

[CreateAssetMenu (fileName = "Utility data", menuName = "Scriptable/Utility data")]
public class UtilityData : ScriptableObject
{
    public string UtilityName;
    public Sprite utilityIcon;
    public UtilityID utilityId;

    [Space]
    public int availableCount;
    public int maxCapacity;
    public float regenerationDuration = 10;
}
