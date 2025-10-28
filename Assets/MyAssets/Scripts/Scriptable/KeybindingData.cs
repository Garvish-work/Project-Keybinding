using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu (fileName = "Keybinding data", menuName = "Scriptable/Keybinding data")]
public class KeybindingData : ScriptableObject
{
    public Color editableButtonColor;
    public Color editableCrossColor;
    public Color nonEditableColor;
    public Dictionary<PlayerCommand, KeyCode> keybinds = new Dictionary<PlayerCommand, KeyCode>();
}
