using System;
using UnityEngine;

public static class ActionHandler 
{
    public static Action<KeyCode, ActionToChange> OnChangeCommand;    
    public static Action<ActionToChange> OnRemoveBindingCommand;
    public static Action OnResetToDefault;    
    public static Action OnWeaponFire;    
    public static Action OnPlayerHeal;    
    public static Action<bool> OnPlayerEdit;    
}
