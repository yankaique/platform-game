using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigibody;
    public HealthBase healthBase;

    [Header("Speed Setup")]
    public float speed;
    public float speedRun;
    public float forceJump = 2;
    public Vector2 friction = new Vector2(.1f, 0);

    [Header("Animation Setup")]
    public SOFloat soJumpScaleY;
    public SOFloat soAnimationDuration;
    // public float jumpScaleY = 1.5f;
    // public float animationDuration = .3f;
    //public float jumpScaleX = 1.7f;
    //public SOFloat soJumpScaleX;


    public Ease ease = Ease.OutBack;

    [Header("Animation Player")]
    public Animator animator;
    public string animationTrigger = "PlayerRun";
    public string animationTriggerDeath = "Player_Death";

    private float _currentSpeed;


    // public Vector2 velocity;

    private void Awake()
    {
        if(healthBase != null)
        {
            healthBase.OnKill += OnPlayerKill;
        }
    }

    private void OnPlayerKill()
    {
        healthBase.OnKill -= OnPlayerKill;
        animator.SetTrigger(animationTriggerDeath);
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
    }
    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = speedRun;
        }else
        {
            _currentSpeed = speed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // myRigibody.MovePosition(myRigibody.position - velocity * Time.deltaTime);
            myRigibody.velocity = new Vector2(-_currentSpeed, myRigibody.velocity.y);
            myRigibody.transform.localScale = new Vector3(-1, 1,1);
            OnPlayerRun(true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //myRigibody.MovePosition(myRigibody.position + velocity * Time.deltaTime);
            myRigibody.velocity = new Vector2(_currentSpeed, myRigibody.velocity.y);
            myRigibody.transform.localScale = new Vector3(1, 1, 1);

            OnPlayerRun(true);
        }else
        {
            OnPlayerRun(false);
        }

        if (myRigibody.velocity.x > 0)
        {
            myRigibody.velocity -= friction;
        }
        else if (myRigibody.velocity.x < 0)
        {
            myRigibody.velocity += friction;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // myRigibody.MovePosition(myRigibody.position - velocity * Time.deltaTime);
            myRigibody.velocity = Vector2.up * forceJump;

            myRigibody.transform.localScale = Vector2.one;
            DOTween.Kill(myRigibody.transform);

            ScaleToJump();
        }
    }

    private void ScaleToJump()
    {
        myRigibody.transform.DOScaleY(soJumpScaleY.Value, soAnimationDuration.Value).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        // myRigibody.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }

    private void OnPlayerRun(bool isRun)
    {
        animator.SetBool(animationTrigger, isRun);
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
