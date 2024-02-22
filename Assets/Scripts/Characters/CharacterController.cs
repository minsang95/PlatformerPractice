using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public event Action<Vector2> OnMovementEvent;
    public event Action OnJumpEvent;
    public event Action OnSlideEvent;
    public event Action OnPauseEvent;

    public void CallMovementEvent(Vector2 direction)
    {
        OnMovementEvent?.Invoke(direction);
    }
    public void CallJumpEvent()
    {
        OnJumpEvent?.Invoke();
    }
    public void CallSlideEvent()
    {
        OnSlideEvent?.Invoke();
    }
    public void CallPauseEvent()
    {
        OnPauseEvent?.Invoke();
    }
}
