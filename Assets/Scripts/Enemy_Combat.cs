using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public int damage = 1;
    public float attackRange = 1.2f;
    public Transform attackPoint;
    public LayerMask playerLayer;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(-damage);
        }

    }

    public void Attack()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

        if (hitPlayers.Length > 0)
        {
            hitPlayers[0].GetComponent<PlayerHealth>().ChangeHealth(-damage);
        }
    }
}