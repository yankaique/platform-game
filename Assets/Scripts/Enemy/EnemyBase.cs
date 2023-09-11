using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 10;

    [Header("Animation")]
    public Animator animator;
    public string triggerAttack = "Enemy_Attack";
    public string triggerDeath = "Enemy_Death";

    public HealthBase healthBase;
    public float timeToDestroy = 1f;

    private void Awake()
    {
        if(healthBase != null)
        {
            healthBase.OnKill += OnEnemyKill;
        }
    }

    private void OnEnemyKill()
    {
        healthBase.OnKill -= OnEnemyKill;
        PlayDeathAnimation();
        Destroy(gameObject, timeToDestroy);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var health = collision.gameObject.GetComponent<HealthBase>();

        if (health != null)
        {
            health.Damage(damage);
            PlayAttackAnimation();
        }
    }

    private void PlayAttackAnimation()
    {
        animator.SetTrigger(triggerAttack);
    }
    private void PlayDeathAnimation()
    {
        animator.SetTrigger(triggerDeath);
    }


    public void Damage(int amount)
    {
        healthBase.Damage(amount);
    }
}
