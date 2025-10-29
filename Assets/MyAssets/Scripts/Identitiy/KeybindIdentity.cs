using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeybindIdentity : MonoBehaviour
{


    [SerializeField] private KeybindingData keybindingData;    
    [SerializeField] private ActionToChange actionToChange;
    [SerializeField] private KeyCode defaultValue;

    [SerializeField] private Button clearButton;
    [SerializeField] private Image keyIcon;
    private Button editButton;

    private TMP_Text keyText; 
    private string previousValue;
    private bool isListening = false;


    private void Awake()
    {
        isListening = false;
        keyText = GetComponentInChildren<TMP_Text>();
        editButton = GetComponent<Button>(); ;
    }


    private void OnEnable()
    {
        ActionHandler.OnResetToDefault += ResetToDefault;
        ActionHandler.OnPlayerEdit += UpdateEditableButton;
    }

    private void OnDisable()
    {
        ActionHandler.OnResetToDefault -= ResetToDefault;
        ActionHandler.OnPlayerEdit -= UpdateEditableButton;
    }

    private void UpdateEditableButton(bool flag)
    {
        clearButton.interactable = flag;
        editButton.interactable = flag;
    }

    private void ResetToDefault()
    {
        //keyText.text = defaultValue.ToString();
        SetKeyText(defaultValue.ToString());
    }


    public void B_BindingPressed()
    {
        previousValue = keyText.text;
        //keyText.text = "Press any key";
        SetKeyText("Press any key");
        isListening = true;
    }

    public void B_RemoveBinding()
    {
        ActionHandler.OnRemoveBindingCommand(actionToChange);
        //keyText.text = string.Empty;
        SetKeyText(string.Empty);
    }

    private void Update()
    {
        if (!isListening) return;

        if (Input.anyKeyDown)
        {
            // Loop through all possible KeyCode values
            foreach (KeyCode keyPressed in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(keyPressed))
                {
                    if (keybindingData.keybinds.ContainsValue(keyPressed))
                    {
                        //keyText.text = previousValue;
                        SetKeyText(previousValue);
                        isListening = false;
                        return;
                    }

                    ActionHandler.OnChangeCommand?.Invoke(keyPressed, actionToChange);
                    Debug.Log("Key pressed: " + keyPressed); 

                    //keyText.text = keyPressed.ToString();
                    SetKeyText(keyPressed.ToString());
                    isListening = false;
                }
            }
        }
    }

    private void SetKeyText (string desireString)
    {
        keyIcon.gameObject.SetActive(true);
        keyText.transform.localScale = Vector3.zero;
        switch (desireString)
        {
            default:
                keyIcon.gameObject.SetActive(false);
                keyText.transform.localScale = Vector3.one;
                break;
            case "Mouse0":
                keyIcon.sprite = keybindingData.mouseImage.mouseLeft;
                break;
            case "Mouse2":
                keyIcon.sprite = keybindingData.mouseImage.mouseMiddle;
                break;
            case "Mouse1":
                keyIcon.sprite = keybindingData.mouseImage.mouseRight;
                break;
        }
        keyText.text = desireString;
    }
}