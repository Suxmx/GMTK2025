
using System.Collections.Generic;
using GMTK;
using GMTK.EventArgs;
using MemoFramework.Extension;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// This class is a simple example of how to build a controller that interacts with PlatformerMotor2D.
/// </summary>
[RequireComponent(typeof(PlatformerMotor2D))]
public class PlayerController2D : MonoBehaviour
{
    public bool Die { get; private set; }
    
    private PlatformerMotor2D _motor;
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    
    private GameObject BulletPrefab;

    private List<SpecialBox> BoxsBuildTime;
    public List<Sprite> BoxSprites = new List<Sprite>();

    // Use this for initialization
    void Start()
    {
        _motor = GetComponent<PlatformerMotor2D>();
        _animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        BoxsBuildTime = new List<SpecialBox>();
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

        if (Input.GetMouseButtonDown(0))
        {
            _motor.HandleBuild();
        }

        if (Input.GetMouseButtonDown(1))
        {
            _motor.HandleFire();
        }

        /*if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ShouldBuild();
        }*/
        
        
    }

    public void RequestDie()
    {
        if(Die)return;
        Die = true;
        // MF
    }
    
    public void RequestRespawn()
    {
        if(!Die)return;
        _motor.frozen = false;
        Die = false;
        MF.Event.Fire(this,OnPlayerRespawn.Create());
    }
}
