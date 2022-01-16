using UnityEngine;

public class MeleeCombat : MonoBehaviour
{

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 50;
    public bool canAttack = true;
    public float attackCooldown = 0.5f;
    public LayerMask enemies;
    public Animator animator;
    private float force = 1500f;

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
            Enemy script = enemy.GetComponent<Enemy>();

            if (script)
            {
                script.takeDamage(attackDamage);
                Rigidbody2D erb = enemy.GetComponent<Rigidbody2D>();
                Vector2 dir = GetComponent<Rigidbody2D>().position - erb.position;
                erb.AddForce(dir.normalized * -force);
            }
            else enemy.GetComponent<Crystal>().Smash();

        }

        animator.SetTrigger("Sword");

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
