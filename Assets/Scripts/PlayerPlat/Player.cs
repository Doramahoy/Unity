using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public static Player instance;
    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //Передвижение
    public float speed;
    public Animator animator;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;
    public bool isAttacking = false;
    public Joystick joystick;
    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //Атака
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public LayerMask Enemy;
    public float attackRange;
    public float damage;
    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //Кол-во HP
    public float health;
    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    //------------------------------------------------------------HPBar--------------------------------------------------------------------------------------------------------------------
    public Image bar;
    public float filldamage = 1f;
    public float fill = 1f;
    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
    private void Update()
    {
        Flip();
        Fireball();
        Move();
        bar.fillAmount = fill;
    }


    //-----------------------------------------------------------------ПЕРЕДВИЖЕНИЕ--------------------------------------------------------------------------------------------------------
    //Передвижение персонажа
    private void Flip()
    {
        if (moveInput.x > 0)
        {
            transform.localScale = new Vector3(7, 7, 1);
        }
        else if (moveInput.x < 0)
        {
            transform.localScale = new Vector3(-7, 7, 1);
        }
    }
    public void Move()
    {
        moveInput.x = joystick.Horizontal;
        rb.MovePosition(rb.position + speed * Time.deltaTime * moveInput);
        animator.SetBool("Run", moveInput.x != 0);
        moveVelocity = moveInput.normalized * speed;
    }
    public void DashPlayer()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerPlatAttack") == false)
        {
            animator.Play("PlayerDash");
            StartCoroutine(Dash());
        }
    }
    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //Анимация
    public void AttackAnim()
    {
        int choose = Random.Range(1, 4);
        if (!isAttacking)
        {
            animator.Play("PlayerPlatAttack " + choose);
            isAttacking = true;
            StartCoroutine(DoAttack());
        }
    }
  public void DeathAnim()
    {
        if (health <= 0)
        {
            animator.Play("EnemyDead");
        }
        bar.fillAmount = fill;
    }
    private void Fireball()
    {
        if (Input.GetKey(KeyCode.B))
        {
            animator.Play("PlayerPlatFireball");
            StartCoroutine(DoAttack());
        }
    }
    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //Атака и удаление
    public void Attack()
    {
        if (timeBtwAttack <= 0)
        {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, Enemy);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
  

    public void Delete()
    {
        Destroy(gameObject);
    }
    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //Получение урона и анимация
    public void TakeDamage(float damageEn)
    {
        filldamage = damageEn / 100;
        health -= damageEn;
        fill -= filldamage;
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerPlatRun") == false)
        {
            animator.Play("PlayerKnockback");
        }

        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerPlatRun") == true)
        {
            animator.Play("PlayerKnockback");
        }
    }
    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //Задержки
    IEnumerator DoAttack()
    {
        speed = 0;

        yield return new WaitForSeconds(0.5f);

        isAttacking = false;
        speed = 5;
    }

    IEnumerator Dash()
    {
        speed = 10;

        yield return new WaitForSeconds(0.3f);

        speed = 5;
    }
    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
}
