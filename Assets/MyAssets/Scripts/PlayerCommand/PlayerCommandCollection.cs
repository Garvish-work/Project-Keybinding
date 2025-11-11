using UnityEngine;

public class PlayerJump : PlayerCommand
{
    public override void Exicute(InputData inputData, WeaponController weaponController)
    {
        Debug.Log("Player jumped");
        if (inputData.isDead) return;

        if (inputData.inAction || inputData.isAiming || inputData.isEditing) return;
        inputData.isJumping = true; 
    }
}


public class PlayerCrouch : PlayerCommand
{
    public override void Exicute(InputData inputData, WeaponController weaponController)
    {
        Debug.Log("Player crouched");
        if (inputData.isDead) return;

        if (!inputData.isCrouchableAction || inputData.isEditing) return;
        inputData.isCrouching = !inputData.isCrouching;
    }
}


public class PlayerKick : PlayerCommand
{
    public override void Exicute(InputData inputData, WeaponController weaponController)
    {
        Debug.Log("Player kicked");
        if (inputData.isDead) return;

        if (inputData.inAction || inputData.isAiming || inputData.isEditing) return;
        inputData.isKicking = true;
    }
}


public class PlayerWeaponFire : PlayerCommand
{
    public override void Exicute(InputData inputData, WeaponController weaponController)
    {
        Debug.Log("Player fired weapon");
        if (inputData.isDead) return;

        if (inputData.inAction || inputData.isEditing) return;

        ActionHandler.OnWeaponFire?.Invoke();

        //if (inputData.isAiming) ActionHandler.OnWeaponFire?.Invoke();
        //else inputData.isPunching = true;
    }
}

public class PlayerWeaponAim : PlayerCommand
{
    public override void Exicute(InputData inputData, WeaponController weaponController)
    {
        Debug.Log("Player aimed weapon");
        if (inputData.isDead) return;

        if (inputData.inAction || inputData.isEditing) return;
        inputData.isAiming = !inputData.isAiming;
    }
}

public class PlayerHeal : PlayerCommand
{
    public override void Exicute(InputData inputData, WeaponController weaponController)
    {
        Debug.Log("Player heal weapon");
        if (inputData.isDead) return;

        if (inputData.inAction || inputData.isEditing) return;
        ActionHandler.OnPlayerHeal?.Invoke();
    }
}

public class PlayerEdit : PlayerCommand
{
    public override void Exicute(InputData inputData, WeaponController weaponController)
    {
        Debug.Log("Player in edit mode");
        inputData.isEditing = !inputData.isEditing;
        ActionHandler.OnPlayerEdit?.Invoke(inputData.isEditing);    
    }
}

public class PlayerReload : PlayerCommand
{
    public override void Exicute(InputData inputData, WeaponController weaponController)
    {
        Debug.Log("Player in reloading");
        if (inputData.isDead) return;

        if (inputData.inAction || inputData.isEditing) return;


        ActionHandler.OnWeaponReloadStart?.Invoke();

        //if (inputData.isAiming) inputData.isReloading = true; //--1

        //inputData.isReloading = inputData.isAiming ? true : false; //--2
    }
}

public class PlayerRevive : PlayerCommand
{
    public override void Exicute(InputData inputData, WeaponController weaponController)
    {
        Debug.Log("Player in revived");
        if (inputData.isEditing) return;

        if (!inputData.isDead) return;
        inputData.isDead = false;
    }
}