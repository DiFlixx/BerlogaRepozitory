using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField]
    private float _jumpForce;
    [SerializeField]
    private float _smoothness;

    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private Rigidbody2D _rb1;
    [SerializeField]
    private Rigidbody2D _rb2;

    [SerializeField]
    private Animator _a1;
    [SerializeField]
    private Animator _a2;

    [SerializeField]
    private Transform _t1;
    [SerializeField]
    private Transform _t2;

    [SerializeField]
    private RobotHelper _robot;
    
    private Animator _animator;
    private Rigidbody2D rb;
    private bool isGrounded;
    private Transform _playerTransform;
    private TemperatureManager _temperatureManager;

    private int _currentChar = 1;

    [SerializeField] private AudioSource snowJumpAudio;

    void Start()
    {
        _temperatureManager = FindAnyObjectByType<TemperatureManager>();
        _animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        _playerTransform = GetComponent<Transform>();
    }

    private void ChangeCharacter()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (_currentChar == 1)
            {
                _currentChar = 2;
                rb = _rb2;
                _animator.SetFloat("HorizontalMove", 0);
                _animator.SetFloat("VerticalMove", 0);
                rb.velocity = Vector3.zero;
                _animator = _a2;
                _playerTransform = _t2;
                _robot.ChangePlayer(2);
                
            }
            else
            {
                _currentChar = 1;
                rb = _rb1;
                rb.velocity = Vector3.zero;
                _animator.SetFloat("HorizontalMove", 0);
                _animator.SetFloat("VerticalMove", 0);
                _animator = _a1;
                _playerTransform = _t1;
                _robot.ChangePlayer(1);
                
            }
        }
    }

    void Update()
    {
        float HorizontalMove = Input.GetAxis("Horizontal") * speed;
        float verticalInput = Input.GetAxis("Vertical");
        float VerticalMove = rb.velocity.y;
        _animator.SetFloat("HorizontalMove", Mathf.Abs(HorizontalMove));
        _animator.SetFloat("VerticalMove", VerticalMove);
        Move();
        CameraMove();
        Flip();
        Jump();
        ChangeCharacter();
    }

    void Jump()
    {
        var hit = Physics2D.BoxCast(transform.position, new Vector3(0.6f, 3, 0), 0, Vector2.down, 0.3f, LayerMask.GetMask("Ground"));
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && hit.collider != null)
        {
            rb.velocity = Vector2.up * _jumpForce;
            snowJumpAudio.Play();
        }
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0);
        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);
    }

    public void SuperJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, _jumpForce * 1.3f);
    }

    private void CameraMove()
    {
        Vector3 targetPosition = new Vector3(_playerTransform.position.x, _playerTransform.position.y, _camera.transform.position.z);
        _camera.transform.position = Vector3.Lerp(_camera.transform.position, targetPosition, Time.deltaTime * _smoothness);
    }

    private void Flip()
    {
        Vector3 currentScale = _playerTransform.localScale;
        if (rb.velocity.x < 0)
        {
            currentScale.x = -Mathf.Abs(currentScale.x);
        }
        else if (rb.velocity.x > 0)
        {
            currentScale.x = Mathf.Abs(currentScale.x);
        }
        _playerTransform.localScale = currentScale;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            isGrounded = true;
        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HeatArea"))
        {
            _temperatureManager.temperatureDecayRate = -3;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("HeatArea"))
        {
            _temperatureManager.temperatureDecayRate = 1;
        }
    }
}
