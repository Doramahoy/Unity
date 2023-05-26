using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballEnemy : MonoBehaviour
{

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //������ �������
    public float timeDestroy;
    public float speed;
    public Rigidbody2D rb;
    Vector3 diference;
    float rotateZ;
    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //���� �������
    public Transform attackPos;
    public LayerMask Enemy;
    public float attackRange;
    public float damageEn;
    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //������ �������
    void Start()
    {
        Transform PlayerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        rb = GetComponent<Rigidbody2D>();

        diference = PlayerPos.position - transform.position;
        rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        rotateZ -= 90;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);

        rb.velocity = diference * speed;
        Invoke(nameof(DestroyBullet), timeDestroy);
    }
    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //�������� �������
    void Update()
    {
       
    }
    
    //�������� �������
    void DestroyBullet()
    {
        Destroy(this.gameObject);
    }
    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //���� �������
    public void Attack()
    {

        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, Enemy);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<Player>().TakeDamage(damageEn);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Attack();
            Destroy(gameObject);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
}
