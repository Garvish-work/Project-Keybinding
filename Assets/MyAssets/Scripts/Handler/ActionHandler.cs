using System;
using UnityEngine;

public static class ActionHandler 
{
    // keybinding actions
    public static Action<KeyCode, ActionToChange> OnChangeCommand;    
    public static Action<ActionToChange> OnRemoveBindingCommand;
    public static Action OnResetToDefault;    

    // weapon actions
    public static Action<WeaponName> OnWeaponChanged;    
    public static Action<WeaponData> OnWeaponFire;    
    public static Action OnChangeWeaponUi;    
    public static Action OnPlayerHitFire;    
    public static Action OnReloadStarted;    
    public static Action OnReloadComplete;    

    // player actions
    public static Action OnPlayerHeal;    
    public static Action<bool> OnPlayerEdit;    
    public static Action OnPlayerGetHit;
    public static Action OnPlayerDead;    
    public static Action OnPlayerRevive;    
}
