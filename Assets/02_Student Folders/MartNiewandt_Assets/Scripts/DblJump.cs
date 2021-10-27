using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class DblJump : MonoBehaviour
{
    [Header("References")]
    [Tooltip("Audio source for DblJump sfx")]
    public AudioSource audioSource;
    [Tooltip("Particles for DblJump vfx")]
    public ParticleSystem[] DblJumpVfx;

    [Header("Parameters")]
    [Tooltip("Whether the DblJump is unlocked at the begining or not")]
    public bool isDblJumpUnlockedAtStart = false;
    [Tooltip("The strength with which the DblJump pushes the player up")]
    public float DblJumpAcceleration = 7f;
    [Tooltip("This will affect how much using the DblJump will cancel the gravity value, to start going up faster. 0 is not at all, 1 is instant")]
    public float DblJumpDownwardVelocityCancelingFactor = 9f;

    [Header("Durations")]
    [Tooltip("Time it takes to consume all the DblJump fuel")]
    public float consumeDuration = 1.5f;
    [Tooltip("Time it takes to completely refill the DblJump while on the ground")]
    public float refillDurationGrounded = 2f;
    [Tooltip("Time it takes to completely refill the DblJump while in the air")]
    public float refillDurationInTheAir = 5f;
    [Tooltip("Delay after last use before starting to refill")]
    public float refillDelay = 1f;

    [Header("Audio")]
    [Tooltip("Sound played when using the DblJump")]
    public AudioClip DblJumpSFX;

    bool m_CanUseDblJump;
    bool used_DblJump;
    PlayerCharacterController m_PlayerCharacterController;
    PlayerInputHandler m_InputHandler;
    float m_LastTimeOfUse;

    // stored ratio for DblJump resource (1 is full, 0 is empty)
    //public float currentFillRatio { get; private set; }
    public bool isDblJumpUnlocked { get; private set; }

    public bool isPlayergrounded() => m_PlayerCharacterController.isGrounded;

    public UnityAction<bool> onUnlockDblJump;

    void Start()
    {
        isDblJumpUnlocked = isDblJumpUnlockedAtStart;

        m_PlayerCharacterController = GetComponent<PlayerCharacterController>();
        DebugUtility.HandleErrorIfNullGetComponent<PlayerCharacterController, DblJump>(m_PlayerCharacterController, this, gameObject);

        m_InputHandler = GetComponent<PlayerInputHandler>();
        DebugUtility.HandleErrorIfNullGetComponent<PlayerInputHandler, DblJump>(m_InputHandler, this, gameObject);

        //currentFillRatio = 1f;

        audioSource.clip = DblJumpSFX;
        audioSource.loop = true;
    }

    void Update()
    {
        // DblJump can only be used if not grounded and jump has been pressed again once in-air
        if(isPlayergrounded())
        {
            m_CanUseDblJump = false;
            used_DblJump = false;
        }
        else if (!m_PlayerCharacterController.hasJumpedThisFrame && m_InputHandler.GetJumpInputDown())
        {
            m_CanUseDblJump = true;
        }

        // DblJump usage
        //bool DblJumpIsInUse = m_CanUseDblJump && isDblJumpUnlocked  && m_InputHandler.GetJumpInputHeld();
        bool DblJumpIsInUse = m_CanUseDblJump && isDblJumpUnlocked  && m_InputHandler.GetJumpInputDown();
        if(DblJumpIsInUse && !used_DblJump)
        {
            used_DblJump = true;
            // store the last time of use for refill delay
            m_LastTimeOfUse = Time.time;

            float totalAcceleration = DblJumpAcceleration;

            // cancel out gravity
            //totalAcceleration += m_PlayerCharacterController.gravityDownForce;

            if (m_PlayerCharacterController.characterVelocity.y < 0f)
            {
                // handle making the DblJump compensate for character's downward velocity with bonus acceleration
                totalAcceleration += DblJumpDownwardVelocityCancelingFactor;
            }

            // apply the acceleration to character's velocity
            m_PlayerCharacterController.characterVelocity += Vector3.up * totalAcceleration;

            // consume fuel
            //currentFillRatio = currentFillRatio - (Time.deltaTime / consumeDuration);

            for (int i = 0; i < DblJumpVfx.Length; i++)
            {
                var emissionModulesVFX = DblJumpVfx[i].emission;
                emissionModulesVFX.enabled = true;
            }

            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        m_CanUseDblJump = false;
    }

    public bool TryUnlock()
    {
        if (isDblJumpUnlocked)
            return false;

        onUnlockDblJump.Invoke(true);
        isDblJumpUnlocked = true;
        m_LastTimeOfUse = Time.time;
        return true;
    }
}
