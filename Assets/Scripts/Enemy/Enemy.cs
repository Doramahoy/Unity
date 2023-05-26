using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //������������ �����
    public float seeDistanceX;
    public float seeDistanceY;
    public Transform playerPosition;
    public Transform thisTransform;
    private Vector2 movement;
    public float speed;
    public Animator animator;
    public bool facingRight = true;
    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //����� �����
    public Transform attackPos;
    public LayerMask Player;
    public float attackRange;
    public int damageEn;
    public bool EnAttack;
    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //���-�� HP �����
    public float healthEnemy;
    public bool isDead = false;
    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    //------------------------------------------------------------HPBar--------------------------------------------------------------------------------------------------------------------
    public Image bar;
    public float filldamage = 1f;
    public float fill = 1f;
    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    public virtual void Update()
    {
        Move();
        bar.fillAmount = fill;
    }
    //-----------------------------------------------------------------������������--------------------------------------------------------------------------------------------------------
    //������������ ���������
    public virtual void Move()
    {
        if (playerPosition.transform.position.x - thisTransform.position.x < seeDistanceX)
        {
            movement = playerPosition.transform.position - thisTransform.position;
            transform.Translate(new Vector2(movement.x * speed * Time.deltaTime, movement.y * speed * Time.deltaTime));
            animator.SetBool("Run", playerPosition.transform.position.x != thisTransform.position.x);
            Flip();
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }

    //�������� �����
    public virtual void AttackAnimation()
    {
        if (EnAttack == true && healthEnemy > 0)
        {
            speed = 0;
            animator.Play("�������� �����");
        }
        else
        {
            speed = 1;
        }
    }
    public virtual void IsStopMoving()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("�������� ��������� �����") == true)
        {
            speed = 0;
        }
        else
        {
            speed = 1;
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("�������� ������") == true)
        {
            speed = 0;
        }
    }

    //������� ���������
    public virtual void Flip()
    {
        if (!facingRight && playerPosition.transform.position.x > thisTransform.position.x)
        {
            facingRight = !facingRight;
            thisTransform.localScale = new Vector2(7, 7);
        }
        else if (facingRight && playerPosition.transform.position.x < thisTransform.position.x)
        {
            facingRight = !facingRight;
            thisTransform.localScale = new Vector2(-7, 7);
        }
    }
    //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    //----------------------------------------------------------����� �����---------------------------------------------------------------------------------------------------------------
    //�������� ����� � TakeDamage
    public virtual void Attack()
    {

        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, Player);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<Player>().TakeDamage(damageEn);
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EnAttack = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        EnAttack = false;
    }

    //���������� ������� �����
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
    //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    //------------------------------------------------------------HP �����-------------------------------------------------------------------------------------------------------------
    public virtual void TakeDamage(float damage)
    {
        if (healthEnemy > 0 && !isDead)
        {
            filldamage = damage / 100;
            fill -= filldamage;
            healthEnemy -= damage;
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("�������� �����") == false && !isDead)
        {
            animator.Play("�������� ��������� �����");
        }

    }
    public virtual void DeathAnim()
    {
        if (healthEnemy <= 0 && isDead == false)
        {
            isDead = true;
        }
        if (isDead)
        {
            animator.Play("�������� ������");
        }
    }
    public virtual void Destroy()
    {
        Destroy(gameObject);
    }
    //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
}


