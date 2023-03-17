using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator),typeof(HashPlayerAnimation))]
public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private CheckCollider _checkCollider;
    [SerializeField] private float _forseAfterImpact = 2;
    [SerializeField] private float _spead;
    [SerializeField] private float _jumpForce;

    private HashPlayerAnimation _hashAnimation;
    private PlayerInput _input;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private bool _isGrounded;
    private bool _isFacingRight = true;
    private float _direction;

    private void Awake()
    {
        _hashAnimation = GetComponent<HashPlayerAnimation>();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _input = new PlayerInput();
        _input.Enable();

        _input.Player.Jump.performed += cxt => OnJump();
    }

    private void OnEnable()
    {
        _player.AddForce += JumpAfterTakingDamage;
        _checkCollider.InflictDamage += JumpAfterDealingDamage;
    }

    private void OnDisable()
    {
        _player.AddForce -= JumpAfterTakingDamage;
        _checkCollider.InflictDamage -= JumpAfterDealingDamage;
    }

    private void FixedUpdate()
    {
        Move(_direction);
    }

    private void Update()
    {
        _direction = _input.Player.Move.ReadValue<float>();
        ControlTheFallAnimation();
    }

    private void Move(float direction)
    {
        _animator.SetFloat(_hashAnimation.SpeedHash, Mathf.Abs(direction));
        _rigidbody.velocity = new Vector2(_spead * _direction, _rigidbody.velocity.y);

        if (_isFacingRight && direction < 0 || _isFacingRight == false && direction > 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

    private void OnJump()
    {
        if (_isGrounded)
        {
            AddForce(_jumpForce);
        }
    }

    private void ControlTheFallAnimation()
    {
        if (_rigidbody.velocity.y != 0)
        {
            _isGrounded = false;
            _animator.SetBool(_hashAnimation.IsJumpingHash, true);
            _animator.SetFloat(_hashAnimation.RBVilocityYHash, _rigidbody.velocity.y);
        }
        else
        {
            _animator.SetBool(_hashAnimation.IsJumpingHash, false);
            _isGrounded = true;
        }
    }

    private void JumpAfterDealingDamage()
    {
        AddForce(_forseAfterImpact);
    }

    private void JumpAfterTakingDamage()
    {
        AddForce();
    }

    private void AddForce (float forseY = 1, float forseX = 1)
    {
        _rigidbody.AddRelativeForce(new Vector2(transform.localScale.x * forseX, transform.localScale.y * forseY), ForceMode2D.Impulse);
    }
}