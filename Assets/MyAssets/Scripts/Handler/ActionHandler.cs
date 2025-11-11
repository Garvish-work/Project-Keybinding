using System;
using UnityEngine;

public static class ActionHandler 
{
    // keybinding actions
    public static Action<KeyCode, ActionToChange> OnChangeCommand;    
    public static Action<ActionToChange> OnRemoveBindingCommand;
    public static Action OnResetToDefault;    
    public static Action<bool> OnPlayerEdit;    

    // weapon actions
    public static Action OnWeaponFire;    
    public static Action<WeaponID> CatchWeaponFire;    
    public static Action OnWeaponReloadStart;    
    public static Action OnWeaponReloadCompleted;    
    public static Action<WeaponID> OnWeaponChange;    

    // player actions
    public static Action OnPlayerHeal;    
    public static Action<int, string> ChangePlayerHealth;    
    public static Action<int> OnPlayerGetHit;
    public static Action OnPlayerDead;    
    public static Action OnPlayerRevive;    

    // ui actions
    public static Action<int> UpdateHealthUi;    
    public static Action<WeaponData> OnUpdateWeaponUi;    
}
