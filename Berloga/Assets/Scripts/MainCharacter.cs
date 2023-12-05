using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _jumpForce;
    [SerializeField]
    private float _smoothness;


    [SerializeField]
    private Camera _camera;

    private Animator _animator;
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isJumping;
    private Transform _playerTransform;

    private int _extraJumps;
    public int extraJumpsValue;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        _extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        _playerTransform = GetComponent<Transform>();
    }

    void Update()
    {
        Move();
        Jump();
        CameraMove();
        Flip();
        DoubleJump();

        float HorizontalMove = Input.GetAxis("Horizontal") * _speed;
        _animator.SetFloat("HorizontalMove", Mathf.Abs(HorizontalMove));
    }

    void DoubleJump()
    {
        if (isGrounded)
        {
            _extraJumps = extraJumpsValue;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && _extraJumps > 0)
        {
            rb.velocity = Vector2.up * _jumpForce;
            _extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && _extraJumps == 0 && isGrounded)
        {
            rb.velocity = Vector2.up * _jumpForce;
        }
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0);
        rb.velocity = new Vector2(movement.x * _speed, rb.velocity.y);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, _jumpForce);
            isJumping = true;

        }
    }

    private void CameraMove()
    {
        Vector3 targetPosition = new Vector3(_playerTransform.position.x, _playerTransform.position.y, _camera.transform.position.z);
        _camera.transform.position = Vector3.Lerp(_camera.transform.position, targetPosition, Time.deltaTime * _smoothness);
    }

    private void Flip()
    {
        Vector3 currentScale = transform.localScale;
        if (rb.velocity.x < 0)
        {
            currentScale.x = -Mathf.Abs(currentScale.x);
        }
        else if (rb.velocity.x > 0)
        {
            currentScale.x = Mathf.Abs(currentScale.x);
        }
        transform.localScale = currentScale;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = true;
            isJumping = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}

