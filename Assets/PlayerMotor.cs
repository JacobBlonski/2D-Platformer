using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class PlayerMotor : MonoBehaviour
{

    Vector2 direction;
    private bool canJump = true;
    private Rigidbody2D rigidbody2D;
    private Animator _animator;
    public float speed = 5;
    public float jumpForce = 5;
    public float dashForce = 50;
    public float dashTime = 0.2f;
    public float maxSpeed = 10;
    public float stopingForce = 10;
    public float multijump;
    public float multijumps = 2;
    private float stoppingForce;
    private float stoppingPoint = 0.1f;
    private float max_jumps;
    private int _jumpcount;
    private int maxJumpCount;
    private bool _canJump = true;
    private bool _isDashing = false;
    private int _jumpCount;
    private float initXScale;

    private void Start()
    { 
     rigidbody2D = GetComponent<Rigidbody2D>();
     _animator = GetComponent<Animator>();
     initXScale = transform.localScale.x;
    
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rigidbody2D.AddForce(new Vector2(direction.x * speed, 0));

        MaxSpeed();
        PlayerStopping();
        if (direction.x != 0)
        {
            _animator.SetBool("IsMoving", true);
        }
        else
        {
            _animator.SetBool("IsMoving", false);
        }

        if (direction.x > 0)
        {

            transform.localScale = new Vector3(initXScale, transform.localScale.y, transform.localScale.z);

        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector3(-initXScale, transform.localScale.y, transform.localScale.z);

        }
    }
            private void MaxSpeed()
            {
                if (_isDashing)
                {
                    return;
                }
                if (rigidbody2D.linearVelocityX >= maxSpeed)
                {
                    rigidbody2D.linearVelocityX = maxSpeed;
                }
                else if (rigidbody2D.linearVelocityX <= -maxSpeed)
                {
                    rigidbody2D.linearVelocityX = -maxSpeed;
                }
            }

    private void PlayerStopping()
    {
        if (direction.x == 0 && rigidbody2D.linearVelocityX != 0)
        {
            rigidbody2D.AddForce(new Vector2(-rigidbody2D.linearVelocityX * stoppingForce, 0));
        }
    }

    private void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }

    private void OnJump()
    {
        if (canJump)
        {

            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _jumpcount++;
            if (_jumpcount >= maxJumpCount)
            {

                _canJump = false;
            }

        }

    }

    private void OnDash()
    {
        if(_isDashing)
        {
            return;
        }
        _isDashing = true;
        rigidbody2D.AddForce(new Vector2(direction.x * dashForce,0), ForceMode2D.Impulse);
        StartCoroutine(ResetDash(dashTime));
    }

    IEnumerator ResetDash(float timeToRest)
    {
        yield return new WaitForSeconds(timeToRest);
        _isDashing = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _canJump = true;
        _jumpCount = 0;
    }
}



