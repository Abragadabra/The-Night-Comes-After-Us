using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // �������� ��� ������������ ������
    public float speed;
    public float jumpForce;

    private float moveInput;

    // ���������� ������
    private Rigidbody2D rb;
    private Animator anim;

    public VectorValue pos;

    // ���������� ��� ������
    private bool isGrounded;

    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    // ���������� ��� �������� ������
    private bool facingRight = true;
    

    // ���������� ��� ������
    public AudioClip Step;
    public AudioClip Whoosh;
    public AudioClip Hit;

    private AudioSource playerAudio;

    // ���������� ��� ������
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 1;
    private bool isAttacked = true;

    private void Start()
    {
        transform.position = pos.initialValue;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        PlayerPrefs.SetInt("NoWeapon", 0);
        PlayerPrefs.Save();
    }

    private void FixedUpdate()
    {
        if (rb != null)
        {
            moveInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

            if (facingRight == false && moveInput > 0)
            {
                Flip();
            }

            else if (facingRight == true && moveInput < 0)
            {
                Flip();
            }

            if (moveInput == 0)
            {
                anim.SetBool("isRunning", false);
            }
            else
            {
                anim.SetBool("isRunning", true);
            }
        }
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded == true && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isAttacked)
                Attack();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;

        scaler.x *= -1;

        transform.localScale = scaler;
    }

    public void stepSound()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded == true)
        {
            playerAudio.PlayOneShot(Step);
        }

    }

    public void whooshSound()
    {
        playerAudio.PlayOneShot(Whoosh);
    }

    public void StopAttack()
    {
        anim.SetTrigger("isStopAttack");
    }

    private void Attack()
    {
        if (PlayerPrefs.GetInt("NoWeapon") == 1)
        {
            anim.SetTrigger("isAttacked");

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
                playerAudio.PlayOneShot(Hit);
            }
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void setActiveAttack()
    {
        isAttacked = true;
    }

    public void setInactiveAttack()
    {
        isAttacked = false;
    }
}
