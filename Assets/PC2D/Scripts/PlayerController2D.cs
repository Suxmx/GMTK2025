
using System.Collections.Generic;
using GMTK;
using MemoFramework.Extension;
using UnityEngine;

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

    private GameObject BoxsPrefab;

    private List<SpecialBox> BoxsBuildTime;
    [SerializeField] private List<Sprite> BoxSprites = new List<Sprite>();

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

        if (Input.GetButtonDown(PC2D.Input.DASH))
        {
            ShouldBuild();
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

    public void ShouldBuild()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.down, Mathf.Infinity, _motor.checkMask);
        if (hit.collider != null && ((this.transform.position.y - hit.transform.position.y) > 2.0F))
        {
            /*
            Debug.DrawRay(this.transform.position, Vector2.down * 10f, Color.red, 1f);
            Debug.Log(hit.transform.position);
            */
            SpecialBoxManager.instance.BuildBox(this.transform.position + new Vector3(0,hit.transform.position.y-this.transform.position.y+0.5F,0));
            /*GameObject go = Instantiate(BoxsPrefab, hit.transform.position+new Vector3(0,0.5f,0), Quaternion.identity);
            SpecialBox sb = go.GetComponent<SpecialBox>();
            sb.sprite = BoxSprites[(int)SeasonManager.Instance.CurrentSeason];
            BoxsBuildTime.Add(sb);*/
        }
    }
}
