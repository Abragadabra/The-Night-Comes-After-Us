using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator anim;

    public int maxHealth = 4;
    public Vector3 startPosition;

    private int currentHealth;
    private Collider2D CL;

    private void Start()
    {
        currentHealth = maxHealth;
        CL = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = startPosition;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        anim.SetTrigger("dieTrigger");
    }

    public void cleanCorpse()
    {
        Destroy(gameObject);
    }

    public void DeleteCL()
    {
        CL.enabled = false;
    }
}
