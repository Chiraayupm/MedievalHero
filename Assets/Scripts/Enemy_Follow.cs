using UnityEngine;
using System;
using UnityEngine.InputSystem.Controls;

public class Enemy_Follow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D rb;
    private Transform player;
    private Animator anim;
    private float attackCooldownTimer;

    public float speed = 2f;
    public int facing = -1;
    public EnemyState Estate;
    public float attackRange = 1.2f;
    public float attackCooldown = 2;
    public float playerRange = 5;
    public LayerMask playerLayer;
    public Transform detectionPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("isIdle", true);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Estate);

        CheckPlayer();


        if (attackCooldownTimer > 0)
        {
            attackCooldownTimer -= Time.deltaTime;
        }


        if (Estate == EnemyState.Walk)
        {
            Chase();
        }
        else if (Estate == EnemyState.Attack)
        {
            rb.linearVelocity = Vector2.zero;
        }

    }


    public void Chase()
    {

        if ((player.position.x > transform.position.x && facing == -1) ||
            (player.position.x < transform.position.x && facing == 1))
        {
            facing *= -1;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }

        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;

    }

    private void CheckPlayer()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(detectionPoint.position, playerRange, playerLayer);
        if (hitPlayer.Length > 0)
        {
            player = hitPlayer[0].transform;
            if (Vector2.Distance(transform.position, player.position) < attackRange && attackCooldownTimer <= 0)
            {
                attackCooldownTimer = attackCooldown;
                ChangeState(EnemyState.Attack);
            }
            else if (Vector2.Distance(transform.position, player.position) > attackRange)
            {
                ChangeState(EnemyState.Walk);
            }
        }
        else
        {
            player = null;
            rb.linearVelocity = Vector2.zero;
            ChangeState(EnemyState.Idle);
        }


    }

    public void ChangeState(EnemyState newState)
    {
        if (Estate == EnemyState.Idle)
        {
            anim.SetBool("isIdle", false);
        }
        else if (Estate == EnemyState.Walk)
        {
            anim.SetBool("isMoving", false);
        }
        else if (Estate == EnemyState.Attack)
        {
            anim.SetBool("isAttacking", false);
        }

        Debug.Log("Changing state from " + Estate + " to " + newState);
        Estate = newState;

        if (Estate == EnemyState.Idle)
        {
            anim.SetBool("isIdle", true);
        }
        else if (Estate == EnemyState.Walk)
        {
            anim.SetBool("isMoving", true);
        }
        else if (Estate == EnemyState.Attack)
        {
            anim.SetBool("isAttacking", true);
        }

    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(detectionPoint.position, playerRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}

public enum EnemyState
{
    Idle,
    Walk,
    Attack,
    Hit,
}