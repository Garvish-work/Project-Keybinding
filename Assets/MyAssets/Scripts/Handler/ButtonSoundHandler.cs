using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundHandler : MonoBehaviour
{
    Button button;
    [SerializeField] private SoundEffects soundEffects;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(RegisterSfx);
    }

    private void RegisterSfx()
    {
        ActionHandler.OnRequestSoundEffect(soundEffects);
    }
}
