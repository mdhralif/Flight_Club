using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emon_Key : MonoBehaviour

{

    public Animator animator;
    public Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    [SerializeField]
    float runSpeed = 5f;
    [SerializeField]
    float jumpSpeed = 5f;
    [SerializeField]
    Transform groundCheck;
    private bool isRight;
    public GameObject attackpoint1, attackpoint2, attackpoint3, attackpoint4, attackpoint5;
    public float attacRadius1;
    public float attacRadius2, attacRadius3, attacRadius4, attacRadius5;
    public LayerMask opponents;
    // Start is called before the first frame update
    void Start()
    {

        //opponents = GetComponent<LayerMask>();
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        flip();
        if (Input.GetButtonDown("Fire1"))
        {

            animator.Play("p1_punch");

        }
        if (Input.GetButtonDown("Fire2"))
        {
            animator.Play("p1_kick");
        }

        //if (Input.GetButtonDown("Fire3"))
        //{
        //    animator.Play("Knife");
        //}


    }
    private void FixedUpdate()
    {



        if (Input.GetKey("d"))
        {
            rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
            animator.Play("p1_walk");

        }
        else if (Input.GetKey("a"))
        {
            rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);
            animator.Play("p1_walk");

        }

        if (Input.GetKeyDown("space") && !(animator.GetBool("isjumping")))
        {
            jump();
        }
    }
    private void flip()
    {
        if (isRight && Input.GetKey("a") || !isRight && Input.GetKey("d"))
        {
            isRight = !isRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    void jump()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
        animator.Play("p1_Jump");
    }
    public void attack1()
    {
        Collider2D[] opponent = Physics2D.OverlapCircleAll(attackpoint1.transform.position, attacRadius1, opponents);
        foreach (Collider2D opponentObject in opponent)
        {
            damage(13);
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
        staticClass.player2Health -= d;
        if (staticClass.player1Health<=0)
        {
            die();
        }
    }
    void die()
    {
        if (staticClass.player1Health <= 0 && staticClass.player1Health< staticClass.player2Health)
        {
            animator.Play("p1_dead");
        }
    }
}
