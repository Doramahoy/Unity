using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Necromancer : Enemy
{
    void Start()
    {

    }

    public override void Update()
    {
        base.Update();
        IsStopMoving();
        DeathAnim();
        AttackAnimation();

    }

    public override void AttackAnimation()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("NecroAttack") == true)
        {
            speed = 0;
        }
        if (EnAttack == true && healthEnemy > 0)
        {
            animator.Play("NecroAttack");
        }
    }
    public override void IsStopMoving()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("NecroKnockback") == true)
        {
            speed = 0;
        }
        else
        {
            speed = 1;
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("NecroDead") == true)
        {
            speed = 0;
        }
    }
    public override void TakeDamage(float damage)
    {
        if (healthEnemy > 0 && !isDead)
        {
            filldamage = damage / 100;
            fill -= filldamage;
            healthEnemy -= damage;
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("NecroAttack") == false && !isDead)
        {
            animator.Play("NecroKnockback");
        }

    }
    public override void DeathAnim()
    {
        if (healthEnemy <= 0 && isDead == false)
        {
            isDead = true;
        }
        if (isDead)
        {
            animator.Play("NecroDead");
        }
    }
}
