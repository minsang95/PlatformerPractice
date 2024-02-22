using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _controller;

    private Vector2 _movementDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;
    private Transform _transform;
    private Animator _animator;
    private PlayerAnimationData _animData = new PlayerAnimationData();

    private float speed = 30f;
    private float maxSpeed = 10f;
    private float jumpPower = 20f;
    private float slidePower = 5f;
    private bool slideReady = true;
    WaitForSeconds slideReadySeconds = new WaitForSeconds(1);

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        _animator = GetComponentInChildren<Animator>();
        _animData.Initialize();
    }
    private void Start()
    {
        _controller.OnMovementEvent += Move;
        _controller.OnJumpEvent += Jump;
        _controller.OnSlideEvent += Slide;

        _animator.SetBool(_animData.GroundParameterHash, true);
    }
    private void FixedUpdate()
    {
        ApplyMovement(_movementDirection);
        GroundCheck();
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
        if (_animator.GetBool(_animData.GroundParameterHash))
        {
            if (direction != Vector2.zero)
            {
                _rigidbody.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
                _animator.SetBool(_animData.RunParameterHash, true);
            }
            else
            {
                _animator.SetBool(_animData.RunParameterHash, false);
                _animator.SetBool(_animData.SlideParameterHash, false);
            }

            if (_rigidbody.velocity.x > maxSpeed)
            {
                _rigidbody.velocity = new Vector2(maxSpeed, _rigidbody.velocity.y);
            }
            else if (_rigidbody.velocity.x < -maxSpeed)
            {
                _rigidbody.velocity = new Vector2(-maxSpeed, _rigidbody.velocity.y);
            }
        }
        
    }
    private void Jump()
    {
        if (_animator.GetBool(_animData.GroundParameterHash))
        {
            _rigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            _animator.SetBool(_animData.JumpParameterHash, true);
            SetAnimAir(true);
        }
    }
    private void Slide()
    {
        if (_animator.GetBool(_animData.GroundParameterHash) && slideReady)
        {
            _rigidbody.AddForce(_movementDirection * slidePower, ForceMode2D.Impulse);
            _animator.SetBool(_animData.SlideParameterHash, true);
            StartCoroutine(SlideReady());
        }
    }
    IEnumerator SlideReady()
    {
        slidePower = 0;
        slideReady = false;
        yield return slideReadySeconds;
        slidePower = 5f;
        slideReady = true;
    }

    private void GroundCheck()
    {
        if(_rigidbody.velocity.y < 0)
        {
            Debug.DrawRay(new Vector2(_rigidbody.position.x - 0.3f, _rigidbody.position.y), Vector3.down * 1.05f, new Color(0, 100, 0));
            Debug.DrawRay(new Vector2(_rigidbody.position.x + 0.3f, _rigidbody.position.y), Vector3.down * 1.05f, new Color(0, 100, 0));

            RaycastHit2D rayHit = Physics2D.Raycast(new Vector2(_rigidbody.position.x - 0.3f, _rigidbody.position.y), Vector2.down, 1.05f, LayerMask.GetMask("Ground"));
            RaycastHit2D rayHit2 = Physics2D.Raycast(new Vector2(_rigidbody.position.x + 0.3f, _rigidbody.position.y), Vector2.down, 1.05f, LayerMask.GetMask("Ground"));

            if (rayHit.collider != null || rayHit2.collider != null)
            {
                if (rayHit.distance < 1.05f || rayHit2.distance < 1.05f)
                {
                    SetAnimGround(true);
                }
            }
        }
    }

    private void SetAnimGround(bool b)
    {
        _animator.SetBool(_animData.GroundParameterHash, b);

        _animator.SetBool(_animData.AirParameterHash, !b);
        _animator.SetBool(_animData.JumpParameterHash, !b);
        _animator.SetBool(_animData.FallParameterHash, !b);
    }

    private void SetAnimAir(bool b)
    {
        _animator.SetBool(_animData.AirParameterHash, b);

        _animator.SetBool(_animData.GroundParameterHash, !b);
        _animator.SetBool(_animData.RunParameterHash, !b);
        _animator.SetBool(_animData.SlideParameterHash, !b);
    }
}
