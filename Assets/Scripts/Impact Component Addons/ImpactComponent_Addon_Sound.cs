using UnityEngine;

[DisallowMultipleComponent]
public class ImpactComponent_Addon_Sound : JTools.ImpactComponent_Addon
{
    [Tooltip("Whether or not sounds will play from the player.")] public bool enableSounds = true;
    [Space]
    [Tooltip("The sound that plays whenever the player walks. The rate this plays at is scaled based on speed.")] public AudioClip[] walkSounds;
    [Tooltip("The sound that plays whenever the player jumps.")] public AudioClip jumpingSound;
    [Tooltip("The sound that plays whenever the player lands on the ground.")] public AudioClip landingSound;

    [HideInInspector]
    public bool overrideFootsteps = false; //This can be used by other scripts to tell a sound component that it doesn't need to run the OnPlayerStep events.

    public bool validStepping => owner.motionComponent.isGrounded || owner.motionComponent.isSliding;

    public override void ComponentInitialize(JTools.ImpactController player)
    {
        base.ComponentInitialize(player);

        player.motionComponent.onJump.AddListener(OnPlayerJump);
        player.motionComponent.onLanding.AddListener(OnPlayerLanding);
        player.cameraComponent.onStep.AddListener(OnPlayerStep);
    }

    public void OnPlayerLanding(float intensity)
    {
        if (enableSounds)
        {
            AudioManager.PlayOneShot(landingSound); //If we're allowed to play sounds on landing, we do it here. The timer is reset to prevent spamming.
        }

    }

    public void OnPlayerStep()
    {
        if (enableSounds && !overrideFootsteps)
        {
            PlayStepSound();
        }
    }

    public void PlayStepSound()
    {
        if (validStepping)
            AudioManager.PlayOneShot(walkSounds[Random.Range(0, walkSounds.Length)]);
    }

    public void OnPlayerJump()
    {
        if (enableSounds)
            AudioManager.PlayOneShot(jumpingSound);
    }

}
