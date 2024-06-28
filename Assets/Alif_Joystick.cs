using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alif_Joystick : MonoBehaviour
{

    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    bool isGrounded;
    [SerializeField]
    float runSpeed = 1.5f;
    [SerializeField]
    float jumpSpeed = 5f;
    [SerializeField]
    float dirx;
    public GameObject attackpoint1, attackpoint2, attackpoint3, attackpoint4, attackpoint5;
    public float attacRadius1;
    public float attacRadius2, attacRadius3, attacRadius4, attacRadius5;
    public LayerMask opponents;
    private bool isRight;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        //transform.Translate(Input.GetAxis("Horizontal1") * runSpeed,0, rb2d.velocity.y);
        float dirx = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(dirx * runSpeed, rb2d.velocity.y);
        if (dirx == 0f)
        {


        }
        else if (dirx > 0f || dirx < 0f)
        {
            Debug.Log("asd");
            animator.Play("Run");
        }

        if (Input.GetButtonDown("Jump1"))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
            animator.Play("Jump");
        }

        flip();
        if (Input.GetButtonDown("jFire1"))
        {

            animator.Play("Punch");

        }
        if (Input.GetButtonDown("jFire2"))
        {
            animator.Play("Kick");
        }



    }
    private void FixedUpdate()
    {

    }
    void die()
    {
        if (staticClass.player2Health<=0)
        {
            animator.Play("dead");
        }
    }
    void jump()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
        animator.Play("Jump");
    }
    private void flip()
    {

    }
    public void attack1()
    {
        Collider2D[] opponent = Physics2D.OverlapCircleAll(attackpoint1.transform.position, attacRadius1, opponents);
        foreach (Collider2D opponentObject in opponent)
        {
            damage(9);
        }
    }
    public void attack2()
    {
        Collider2D[] opponent = Physics2D.OverlapCircleAll(attackpoint2.transform.position, attacRadius2, opponents);
        foreach (Collider2D opponentObject in opponent)
        {
            damage(13);
        }
    }
    public void attack3()
    {
        Collider2D[] opponent = Physics2D.OverlapCircleAll(attackpoint3.transform.position, attacRadius3, opponents);
        foreach (Collider2D opponentObject in opponent)
        {
            damage(20);
        }
    }
    public void attack4()
    {
        Collider2D[] opponent = Physics2D.OverlapCircleAll(attackpoint4.transform.position, attacRadius4, opponents);
        foreach (Collider2D opponentObject in opponent)
        {
            damage(4);
        }
    }
    //public void attack5()
    //{
    //    Collider2D[] opponent = Physics2D.OverlapCircleAll(attackpoint5.transform.position, attacRadius5, opponents);
    //    foreach (Collider2D opponentObject in opponent)
    //    {
    //        damage(20);
    //    }
    //}
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackpoint1.transform.position, attacRadius1);
        Gizmos.DrawWireSphere(attackpoint2.transform.position, attacRadius2);
        Gizmos.DrawWireSphere(attackpoint3.transform.position, attacRadius3);
        Gizmos.DrawWireSphere(attackpoint4.transform.position, attacRadius4);
        Gizmos.DrawWireSphere(attackpoint5.transform.position, attacRadius5);
    }
    void damage(int d)
    {
        staticClass.player1Health -= d;

        if (staticClass.player2Health <= 0)
        {
            die();
            
        }
    }
}
