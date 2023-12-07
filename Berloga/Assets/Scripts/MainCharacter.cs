using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float smoothness;

    [SerializeField] private Camera camera;

    private Animator _animator;
    private Rigidbody2D _rb;
    private bool _isGrounded;
    private bool _isJumping;
    private Transform _playerTransform;
    
    [SerializeField] private AudioSource jumpAudio;
    [SerializeField] private AudioSource doubleJumpAudio;
    
    private int _extraJumps;
    public int extraJumpsValue;
    
    private readonly float _doubleTapTime = 1f;
    private float _elapsedTime;
    private int _pressCount;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        _extraJumps = extraJumpsValue;
        _rb = GetComponent<Rigidbody2D>();
        _playerTransform = GetComponent<Transform>();
    }

    void Update()
    {
        Move();
        Jump();
        CameraMove();
        Flip();
        DoubleJump();
        SoundDoubleJump();

        float horizontalMove = Input.GetAxis("Horizontal") * speed;
        _animator.SetFloat("HorizontalMove", Mathf.Abs(horizontalMove));
    }
    
    void SoundDoubleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _pressCount++;
        }
        
        if (_pressCount > 0)
        {
            _elapsedTime += Time.deltaTime;
            
            if(_elapsedTime > _doubleTapTime)
            {
                ResetPressTimer();
            }
            else if(_pressCount == 2)
            {
                doubleJumpAudio.Play();
                ResetPressTimer();
            }
        }
    }
    
    private void ResetPressTimer()
    {
        _pressCount = 0;
        _elapsedTime = 0;
    }
    
    void DoubleJump()
    {
        if (_isGrounded)
        {
            _extraJumps = extraJumpsValue;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && _extraJumps > 0)
        {
            _rb.velocity = Vector2.up * jumpForce;
            _extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && _extraJumps == 0 && _isGrounded)
        {
            _rb.velocity = Vector2.up * jumpForce;
        }
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0);
        _rb.velocity = new Vector2(movement.x * speed, _rb.velocity.y);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            jumpAudio.Play();
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
            _isJumping = true;

        }
    }

    private void CameraMove()
    {
        var position = camera.transform.position;
        var position1 = _playerTransform.position;
        Vector3 targetPosition = new Vector3(position1.x, position1.y, position.z);
        position = Vector3.Lerp(position, targetPosition, Time.deltaTime * smoothness);
        camera.transform.position = position;
    }

    private void Flip()
    {
        Vector3 currentScale = transform.localScale;
        
        if (_rb.velocity.x < 0)
        {
            currentScale.x = -Mathf.Abs(currentScale.x);
        }
        else if (_rb.velocity.x > 0)
        {
            currentScale.x = Mathf.Abs(currentScale.x);
        }
        transform.localScale = currentScale;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            _isGrounded = true;
            _isJumping = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }
}