using Unity.VisualScripting;
using UnityEngine;

public class UtilityManager : MonoBehaviour
{
    public static UtilityManager instance;

    UtilityData currentUtilityData;
    [SerializeField] private UtilityBehaviour currentUtility;

    [Space]
    [SerializeField] private UtilityBehaviour utilityHeal;

    private void OnEnable()
    {
        ActionHandler.OnUseUtility += UseUtility;
    }

    private void OnDisable()
    {
        ActionHandler.OnUseUtility -= UseUtility;
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ChangeUtility(UtilityID.HEAL);
    }

    private void UseUtility()
    {
        if (currentUtilityData.availableCount <= 0)
        {
            ActionHandler.OnNoUtility?.Invoke(); 
            return;
        }

        currentUtility.Consume();
        ActionHandler.OnCatchUtility?.Invoke(currentUtilityData.utilityId);
    }

    private void ChangeUtility(UtilityID _utilityID)
    {
        switch (_utilityID)
        {
            case UtilityID.HEAL:
                currentUtility = utilityHeal;
                currentUtilityData = currentUtility.GetUtilityData();
                ActionHandler.OnUpdateUtilityUi?.Invoke(currentUtilityData, UiUpdateType.FULL);
                break;
        }
    }
}
