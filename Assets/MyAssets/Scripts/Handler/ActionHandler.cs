using System;
using UnityEngine;

public static class ActionHandler 
{
    // keybinding actions
    public static Action<KeyCode, ActionToChange> OnChangeCommand;    
    public static Action<ActionToChange> OnRemoveBindingCommand;
    public static Action OnResetToDefault;    
    public static Action<bool> OnPlayerEdit;    

    // utility actions
    public static Action OnUseUtility;    
    public static Action<UtilityID> OnCatchUtility;    
    public static Action<int, string> ChangePlayerHealth;    
    public static Action OnHealingCompleted;    
    public static Action<UtilityData, UiUpdateType> OnUpdateUtilityUi;
    public static Action OnNoUtility;

    // weapon actions
    public static Action OnWeaponFire;    
    public static Action<WeaponID> CatchWeaponFire;    
    public static Action OnWeaponReloadStart;    
    public static Action OnWeaponReloadCompleted;    
    public static Action<WeaponID> OnWeaponChange;
    public static Action OnNoAmmo;

    // player actions
    public static Action<int> OnPlayerGetHit;
    public static Action OnPlayerDead;    
    public static Action OnPlayerRevive;    

    // ui actions
    public static Action<int> UpdateHealthUi;    
    public static Action<WeaponData, UiUpdateType> OnUpdateWeaponUi;    
}
