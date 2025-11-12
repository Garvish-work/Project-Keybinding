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
    WEAPON_AMMO
}