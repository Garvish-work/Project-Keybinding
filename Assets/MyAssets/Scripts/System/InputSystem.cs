using UnityEngine;

public class InputSystem : MonoBehaviour
{
    [SerializeField] public KeybindingData keybindingData;
    [SerializeField] public InputData inputData;

    PlayerCommand playerCrouchCommand = new PlayerCrouch();
    PlayerCommand playerKickCommand = new PlayerKick();
    PlayerCommand playerJumpCommand = new PlayerJump();
    PlayerCommand playerweaponFire = new PlayerWeaponFire();
    PlayerCommand playerweaponAim = new PlayerWeaponAim();
    PlayerCommand playerHealCommand = new PlayerHeal();
    PlayerCommand playerEditCommand = new PlayerEdit();
    PlayerCommand playerReloadCommand = new PlayerReload();
    PlayerCommand playerRevivedCommand = new PlayerRevive();

    private void OnEnable()
    {
        ActionHandler.OnChangeCommand += ChangeBindings;
        ActionHandler.OnRemoveBindingCommand += RemoveBindingCommand;
    }

    private void OnDisable()
    {
        ActionHandler.OnChangeCommand -= ChangeBindings;
        ActionHandler.OnRemoveBindingCommand -= RemoveBindingCommand;
    }

    private void Start()
    {
        B_ResetToDefaut();
    }

    private void DefaultValues()
    {
        ChangeBindings(KeyCode.C, ActionToChange.CROUCHING);
        ChangeBindings(KeyCode.Q, ActionToChange.KICKING);
        ChangeBindings(KeyCode.Space, ActionToChange.JUMING);
        ChangeBindings(KeyCode.Mouse0, ActionToChange.WEAPON_FIRE);
        ChangeBindings(KeyCode.Mouse1, ActionToChange.WEAPON_AIM);
        ChangeBindings(KeyCode.H, ActionToChange.PLAYER_HEAL);
        ChangeBindings(KeyCode.Escape, ActionToChange.EDITING);
        ChangeBindings(KeyCode.R, ActionToChange.PLAYER_RELOADING);
        ChangeBindings(KeyCode.V, ActionToChange.PLAYER_REVIVED);
    }

    private void Update()
    {
        foreach (var bind in keybindingData.keybinds)
        {
            if (Input.GetKeyDown(bind.Value))
            {
                bind.Key.Exicute(inputData);
            }
        }
    }

    private void ChangeBindings(KeyCode keyTochange, ActionToChange actionToChange)
    {
        switch (actionToChange)
        {
            case ActionToChange.CROUCHING:
                keybindingData.keybinds[playerCrouchCommand] = keyTochange;
                break;
            case ActionToChange.JUMING:
                keybindingData.keybinds[playerJumpCommand] = keyTochange;
                break;
            case ActionToChange.KICKING:
                keybindingData.keybinds[playerKickCommand] = keyTochange;
                break;
            case ActionToChange.WEAPON_FIRE:
                keybindingData.keybinds[playerweaponFire] = keyTochange;
                break;
            case ActionToChange.WEAPON_AIM:
                keybindingData.keybinds[playerweaponAim] = keyTochange;
                break;
            case ActionToChange.PLAYER_HEAL:
                keybindingData.keybinds[playerHealCommand] = keyTochange;
                break;
            case ActionToChange.EDITING:
                keybindingData.keybinds[playerEditCommand] = keyTochange;
                break;
            case ActionToChange.PLAYER_RELOADING:
                keybindingData.keybinds[playerReloadCommand] = keyTochange;
                break;
            case ActionToChange.PLAYER_REVIVED:
                keybindingData.keybinds[playerRevivedCommand] = keyTochange;
                break;
        }
    }

    private void RemoveBindingCommand(ActionToChange actionToChange)
    {
        switch (actionToChange)
        {
            case ActionToChange.CROUCHING:
                keybindingData.keybinds.Remove(playerCrouchCommand);
                break;
            case ActionToChange.JUMING:
                keybindingData.keybinds.Remove(playerJumpCommand);
                break;
            case ActionToChange.KICKING:
                keybindingData.keybinds.Remove(playerKickCommand);
                break;
            case ActionToChange.WEAPON_FIRE:
                keybindingData.keybinds.Remove(playerweaponFire);
                break;
            case ActionToChange.WEAPON_AIM:
                keybindingData.keybinds.Remove(playerweaponAim);
                break;
            case ActionToChange.PLAYER_HEAL:
                keybindingData.keybinds.Remove(playerHealCommand);
                break;
            case ActionToChange.PLAYER_RELOADING:
                keybindingData.keybinds.Remove(playerReloadCommand);
                break;
        }
    }

    public void B_ResetToDefaut()
    {
        DefaultValues();
        ActionHandler.OnResetToDefault?.Invoke(); 
    }
}