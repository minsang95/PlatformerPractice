using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : CharacterController
{
    public void OnMovement(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMovementEvent(moveInput);
    }

    public void OnJump()
    {
        CallJumpEvent();
    }
    public void OnSlide()
    {
        CallSlideEvent();
    }
    public void OnPause()
    {
        CallPauseEvent();
    }
}
