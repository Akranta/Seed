using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Motion : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private int lives = 5;
    [SerializeField] private float jumpForce = 5f;
    // Start is called before the first frame update

    private Rigidbody2D rigibody;
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    private void Run()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        //transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed + Time.deltaTime);
        transform.position += dir * speed * Time.deltaTime;
        spriteRenderer.flipX = dir.x < 0f;
    }

    private void Awake()
    {
        rigibody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Jump()
    {
        rigibody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private bool isGrounded = false;

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGrounded = collider.Length > 2;
    }
    private void FixedUpdate()
    {
        CheckGround();
    }
    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            Run();
            anim.SetBool("isrun", true);
        }
        else
        {
            anim.SetBool("isrun", false);
        }
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
            anim.SetBool("isjump", true);
        }
        else
        {
            anim.SetBool("isjump", false);
        }
    }
    void Start()
    {

    }
}