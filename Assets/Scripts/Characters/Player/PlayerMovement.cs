using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _controller;

    private Vector2 _movementDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;
    private Transform _transform;

    private float speed = 30f;
    private float maxSpeed = 10f;
    private float jumpPower = 10f;
    private float slidePower = 5f;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
    }
    private void Start()
    {
        _controller.OnMovementEvent += Move;
        _controller.OnJumpEvent += Jump;
        _controller.OnSlideEvent += Slide;
    }
    private void FixedUpdate()
    {
        ApplyMovement(_movementDirection);
    }
    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
        if (direction.x > 0)
            _transform.localScale = new Vector3(1, 1, 1);
        else if(direction.x < 0)
            _transform.localScale = new Vector3(-1, 1, 1);
    }
    private void ApplyMovement(Vector2 direction)
    {
        _rigidbody.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);

        if (_rigidbody.velocity.x > maxSpeed)
        {
            _rigidbody.velocity = new Vector2(maxSpeed, _rigidbody.velocity.y);
        }
        else if (_rigidbody.velocity.x < -maxSpeed)
        {
            _rigidbody.velocity = new Vector2(-maxSpeed, _rigidbody.velocity.y);
        }
    }
    private void Jump()
    {
        _rigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }
    private void Slide()
    {
        _rigidbody.AddForce(_movementDirection * slidePower, ForceMode2D.Impulse);
    }
}
