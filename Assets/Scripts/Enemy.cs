using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHP = 100;
    int currentHP;
    public GameObject bloodEffect;
    public HealthBar normalHealthBar;
    public HealthBar worldHealthBar;

    Animator animator;

    void Start()
    {
        currentHP = maxHP;
        normalHealthBar.SetMaxHealth(currentHP);
        worldHealthBar.SetMaxHealth(currentHP);
        animator = GetComponent<Animator>();
    }
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        normalHealthBar.SetHealth(currentHP);
        worldHealthBar.SetHealth(currentHP);
        animator.SetTrigger("Hurt");
        Instantiate(bloodEffect, transform.position, Quaternion.identity);

        if (currentHP <= 0)
            Die();
    }

    void Die()
    {
        animator.SetTrigger("Death");

        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;
        worldHealthBar.gameObject.SetActive(false);
        this.enabled = false;
    }
}
