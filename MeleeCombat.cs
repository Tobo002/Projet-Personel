using UnityEngine;

public class MeleeCombat : MonoBehaviour
{

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 50;
    public bool canAttack = true;
    public float attackCooldown = 0.5f;
    public LayerMask enemies;

    void Update()
    {
        if (Input.GetButton("Fire1") && canAttack) { Attack(); }
    }

    void Attack()
    {

        canAttack = false;

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemies);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("we hit " + enemy.name);
            enemy.GetComponent<Enemy>().takeDamage(attackDamage);
        }

        Invoke(nameof(ResetAttack), attackCooldown);

    }

    void ResetAttack()
    {
        canAttack = true;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
