using System.Drawing;

public enum ActionToChange
{
    CROUCHING,
    JUMING,
    KICKING,
    WEAPON_FIRE,
    WEAPON_AIM,
    PLAYER_HEAL,
    EDITING,
    PLAYER_RELOADING,
    PLAYER_REVIVED
}

public enum WeaponID
{
    HANDS,
    AK46
}

public enum AmmoType
{
    FINITY,
    INFINITY
}

public enum UiUpdateType
{
    FULL,
    WEAPON_AMMO,
    UTILITY_COUNT
}

public enum UtilityID
{
    HEAL
}

public enum SoundEffects
{
    BUTTON_CLICK_P, 
    BUTTON_CLICK_N,
    CROUCH,
    KICK_WHOOSH,
    PUNCH_WHOOSH,
    AK_SFX,
    WEAPON_CHANGE,
    AK_RELOAD,
    __NULL,
    DRINK_POTION,
    NO_AMMO,
    GET_PUNCHED,
    NO_UTILITY
}