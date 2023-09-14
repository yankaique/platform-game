using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigibody;
    public HealthBase healthBase;

    [Header("Setup")]
    public SOPlayerSetup sOPlayerSetup;

    [Header("Animation Setup")]
    public Animator animator;

    [Header("Movements SO")]
    public SOFloat soJumpScaleY;
    public SOFloat soAnimationDuration;
    // public float jumpScaleY = 1.5f;
    // public float animationDuration = .3f;
    //public float jumpScaleX = 1.7f;
    //public SOFloat soJumpScaleX;
    // public Vector2 velocity;


    public Ease ease = Ease.OutBack;

    private float _currentSpeed;

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
        animator.SetTrigger(sOPlayerSetup.animationTriggerDeath);
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
            _currentSpeed = sOPlayerSetup.speedRun;
        }else
        {
            _currentSpeed = sOPlayerSetup.speed;
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
            myRigibody.velocity -= sOPlayerSetup.friction;
        }
        else if (myRigibody.velocity.x < 0)
        {
            myRigibody.velocity += sOPlayerSetup.friction;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // myRigibody.MovePosition(myRigibody.position - velocity * Time.deltaTime);
            myRigibody.velocity = Vector2.up * sOPlayerSetup.forceJump;

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
        animator.SetBool(sOPlayerSetup.animationTrigger, isRun);
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
