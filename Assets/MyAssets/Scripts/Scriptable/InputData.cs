using UnityEngine;

[CreateAssetMenu (fileName = "Input data", menuName = "Scriptable/Input data")]
public class InputData : ScriptableObject
{
    public bool isDead = false;
    public int playerHealth = 3;
    public int playerMaxHealth = 3;

    [Space]
    public bool isEditing = false;
    public bool inAction = false;
    public bool isCrouchableAction = false;

    public bool isCrouching = false;
    public bool isAiming = false;

    [Space]
    public bool isJumping = false;
    public float jumpDuration = 2f;

    [Space]
    public bool isKicking = false;
    public float kickDuration = 2f;

    [Space]
    public bool isPunching = false;
    public float punchDuration = 2f;

    [Space]
    public bool isReloading = false;
    public float reloadDuration = 1.5f;

    [Space]
    public float healDuration = 1f;

    [Space]
    public float reviveDuration = 2f;
}

