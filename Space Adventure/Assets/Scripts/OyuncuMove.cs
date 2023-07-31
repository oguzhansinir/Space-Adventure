using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuMove : MonoBehaviour
{

    [Header("Components")]
    private Rigidbody2D _rb;


    [Header("Layer Masks")]
    [SerializeField] LayerMask _groundLayer;


    [Header("Movement Variables")]
    [SerializeField] private float _movementAcceleration;
    [SerializeField] private float _maxMoveSpeed;
    [SerializeField] private float _groundLinearDrag;
    private float _horizontalDirection;
    private bool _changingDirection => (_rb.velocity.x > 0f && _horizontalDirection < 0f) || (_rb.velocity.x < 0f && _horizontalDirection > 0f);


    [Header("Jump Variables")]
    [SerializeField] private float _jumpForce = 12f;
    [SerializeField] private float _airLinearDrag = 2.5f;
    [SerializeField] private float _fallMultiplier = 8f;
    [SerializeField] private float _lowJumpFallMultiplier = 5f;
    [SerializeField] private float _jumpDelay = 0.15f;
    [SerializeField] private int _extraJump = 1;
    private float _jumpTimer;
    private int _extraJumpsValue;
    private bool _canJump => _jumpTimer > Time.deltaTime && (_onGround || _extraJumpsValue > 0);

    [Header("Ground Collision Variables")]
    [SerializeField] private float _groundRaycastLenght;
    private bool _onGround;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _horizontalDirection = GetInput().x;

        if (_canJump)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        CheckCollisions();
        MoveCharacter();

        if (_onGround)
        {
            _extraJumpsValue = _extraJump;
            ApplyGroundLinearDrag();
        }
        else
        {
            ApplyAirLinearDrag();
            FallMultiplier();
        }

    }


    private Vector2 GetInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void MoveCharacter()
    {
        _rb.AddForce(new Vector2(_horizontalDirection, 0f) * _movementAcceleration);

        if (Mathf.Abs(_rb.velocity.x) > _maxMoveSpeed)
        {
            _rb.velocity = new Vector2(Mathf.Sign(_rb.velocity.x) * _maxMoveSpeed, _rb.velocity.y);
        }
    }

    private void ApplyGroundLinearDrag()
    {
        if (Mathf.Abs(_horizontalDirection) < 0.4f || _changingDirection)
        {
            _rb.drag = _groundLinearDrag;
        }
        else
        {
            _rb.drag = 0f;
        }
    }

    private void ApplyAirLinearDrag()
    {
        _rb.drag = _airLinearDrag;
    }
    private void Jump()
    {
        if (!_onGround)
        {
            _extraJumpsValue--;
        }

        _rb.velocity = new Vector2(_rb.velocity.x, 0f);
        _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void FallMultiplier()
    {
        if (_rb.velocity.y < 0f)
        {
            _rb.gravityScale = _fallMultiplier;
        }
        else if (_rb.velocity.y > 0f && !Input.GetButton("Jump"))
        {
            _rb.gravityScale = _lowJumpFallMultiplier;
        }
        else
        {
            _rb.gravityScale = 1f;
        }
    }
    private void CheckCollisions()
    {
        _onGround = Physics2D.Raycast(transform.position * _groundRaycastLenght, Vector2.down, _groundRaycastLenght, _groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * _groundRaycastLenght);
    }



}
