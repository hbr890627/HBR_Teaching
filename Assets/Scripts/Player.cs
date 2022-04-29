using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 500f;
    public int attackDamage = 40;
    public float attackRate = 0.6f;
    float nextAttackTime;

    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemiesLayer;


    private Rigidbody2D rigidbody2;
    private Animator animator;

    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        var movement = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movement * speed * Time.deltaTime, 0, 0);
        animator.SetFloat("Speed", Mathf.Abs(movement * speed));

        Vector3 scale = transform.localScale;
        if (movement != 0)
            scale.x = -movement;
        transform.localScale = scale;

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rigidbody2.velocity.y) < 0.01)
        {
            rigidbody2.AddForce(Vector3.up * jumpForce);
        }

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                nextAttackTime = Time.time + 1 / attackRate;
            }
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemiesLayer);
        foreach (var enemy in enemies)
        {
            Debug.Log("hit " + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (!attackPoint)
            return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
