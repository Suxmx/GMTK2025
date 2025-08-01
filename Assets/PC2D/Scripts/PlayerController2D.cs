
using UnityEngine;

/// <summary>
/// This class is a simple example of how to build a controller that interacts with PlatformerMotor2D.
/// </summary>
[RequireComponent(typeof(PlatformerMotor2D))]
public class PlayerController2D : MonoBehaviour
{
    private PlatformerMotor2D _motor;
    private Animator _animator;
    private Rigidbody2D _rigidbody;

    // Use this for initialization
    void Start()
    {
        _motor = GetComponent<PlatformerMotor2D>();
        _animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat("yVelocity", _rigidbody.velocity.y);
        
        if (Mathf.Abs(Input.GetAxis(PC2D.Input.HORIZONTAL)) > PC2D.Globals.INPUT_THRESHOLD)
        {
            _motor.normalizedXMovement = Input.GetAxis(PC2D.Input.HORIZONTAL);
        }
        else
        {
            _motor.normalizedXMovement = 0;
        }

        // FlipHandler(Input.GetAxis(PC2D.Input.HORIZONTAL));

        // Jump?
        if (Input.GetButtonDown(PC2D.Input.JUMP))
        {
            _motor.Jump();
        }

        _motor.jumpingHeld = Input.GetButton(PC2D.Input.JUMP);

        if (Input.GetAxis(PC2D.Input.VERTICAL) < -PC2D.Globals.FAST_FALL_THRESHOLD)
        {
            _motor.fallFast = true;
        }
        else
        {
            _motor.fallFast = false;
        }

        if (Input.GetButtonDown(PC2D.Input.DASH))
        {
            _motor.Dash();
        }
    }

    /*private void FlipHandler(float xVelocity)
    {
        if ((xVelocity < 0 && _motor.facingRight) || (xVelocity > 0 && !_motor.facingRight))
        {
            GetComponent<Transform>().Rotate(0,180,0);
            _motor.facingRight = !_motor.facingRight;
        }
    }*/
}
