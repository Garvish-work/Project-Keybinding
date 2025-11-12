using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UtilityHeal : UtilityBehaviour
{
    [SerializeField] private UtilityData utilityData;
    [SerializeField] private Image fillImage;

    private void Start()
    {
        StartCoroutine(nameof(RegenerateUtility));
    }

    private void OnEnable()
    {
        ActionHandler.OnHealingCompleted += HealingCompleted;
    }

    private void OnDisable()
    {
        ActionHandler.OnHealingCompleted -= HealingCompleted;
    }

    public override void Consume()
    {
        utilityData.availableCount--;
        if (!regenerating) StartCoroutine(nameof(RegenerateUtility));
        else ActionHandler.OnUpdateUtilityUi?.Invoke(utilityData, UiUpdateType.UTILITY_COUNT);
    }

    bool regenerating = false;
    private IEnumerator RegenerateUtility()
    {
        regenerating = true;
        ActionHandler.OnUpdateUtilityUi?.Invoke(utilityData, UiUpdateType.UTILITY_COUNT);

        float timer = 0;
        fillImage.gameObject.SetActive(true);
        while (utilityData.availableCount != utilityData.maxCapacity)
        {
            if (timer < utilityData.regenerationDuration)
            {
                timer += Time.deltaTime;
                fillImage.fillAmount = Mathf.InverseLerp(0, utilityData.regenerationDuration, timer);   
            }
            else
            {
                timer = 0;
                utilityData.availableCount++;
                ActionHandler.OnUpdateUtilityUi?.Invoke(utilityData, UiUpdateType.UTILITY_COUNT);
            }
            yield return null;
        }
        fillImage.gameObject.SetActive(false);

        regenerating = false;
    }

    public override UtilityData GetUtilityData()
    {
        return utilityData;        
    }

    private void HealingCompleted()
    {
        ActionHandler.ChangePlayerHealth?.Invoke(50, "add");
    }
}
