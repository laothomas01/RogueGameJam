using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{

    //Animation States
    [HideInInspector]
    public string PLAYER_IDLE = "PlayerIdleShootAnimation";
    [HideInInspector]
    public string PLAYER_MOVEMENT = "PlayerMovementShoot";
    [HideInInspector]
    public string PLAYER_DEATH = "PlayerDeathAnimation";
    [HideInInspector]
    public string PLAYER_JUMP = "PlayerJumpAnimation";
    [HideInInspector]
    public string PLAYER_HURT = "PlayerHurtAnimation";

    private Animator animator;
    private string currentState;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void ChangeAnimationState(string newState)
    {
        //stop the same animation from interrupting itself
        if (currentState == newState) return;
        //play the animation
        animator.Play(newState);
        //reassign the current state
        currentState = newState;
    }

}
