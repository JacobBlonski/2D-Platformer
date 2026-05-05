using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerMotor : MonoBehaviour
{

    Vector2 direction;
    private bool canJump = true;
    private Rigidbody2D rigidbody2D;
    public float speed = 5;
    public float jumpForce = 5;
    public float maxSpeed = 10;
    public float stopingForce = 10;
    public float multijump;
    public float multijumps = 2;
    private float stoppingForce;
    private float max_jumps;
    private int _jumpcount;
    private int maxJumpCount;
    private bool _canJump;
    private int _jumpCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        rigidbody2D.AddForce(new Vector2(direction.x * speed, 0));

        MaxSpeed();
        PlayerStopping();
    }

    private void MaxSpeed()
    {
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
            if(_jumpcount >= maxJumpCount)
            {

                _canJump = false;
            }
               
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        _canJump = true;
        _jumpCount = 0;
    }
}



