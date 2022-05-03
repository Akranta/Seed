using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speedMove = 3.0f;
    [SerializeField] private GameObject shadow;

    private Rigidbody2D rigibody;
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer shadowSpriteRenderer;
    private float x, y;
    private bool left = true;
    private Vector3 pos, pos2;
    private Animator anim;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            player.transform.position = new Vector3(-6.55f, -3.53f, 0f);
        }
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigibody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        shadowSpriteRenderer = shadow.GetComponentInChildren<SpriteRenderer>();
    }

    void Start()
    {
    }

    void Attack()
    {
        anim.SetBool("isattack", true);
        pos = new Vector3(player.transform.position.x, player.transform.position.y, 0f);
        pos2 = new Vector3(transform.position.x + 7.9f, transform.position.y -9f, 0f);
        if (transform.position.x > player.transform.position.x)
        {
            shadow.transform.position = new Vector3(transform.position.x - 7.9f, transform.position.y - 9f, 0f);
            spriteRenderer.flipX = true;
            shadowSpriteRenderer.flipX = false;
        }
        else
        {
            shadow.transform.position = new Vector3(transform.position.x + 7.9f, transform.position.y - 9f, 0f);
            spriteRenderer.flipX = false;
            shadowSpriteRenderer.flipX = true;
        }
        transform.position = Vector3.MoveTowards(transform.position, pos, speedMove * Time.deltaTime);
    }
    void Chill()
    {
        anim.SetBool("isattack", false);
        if (transform.position.x < 43)
        {
            left = false;
        }
        else if (transform.position.x > 318)
        {
            left = true;
        }
        if (left)
        {
            shadow.transform.position = new Vector3(transform.position.x - 7.9f, transform.position.y - 9f, 0f); //-6.7
            x = 42;
            y = 16f;
        }
        else
        {
            shadow.transform.position = new Vector3(transform.position.x + 7.9f, transform.position.y - 9f, 0f);
            x = 319f;
            y = 16;
        }
        pos = new Vector3(x, y, 0f);
        transform.position = Vector3.MoveTowards(transform.position, pos, speedMove * Time.deltaTime);
        spriteRenderer.flipX = left;
        shadowSpriteRenderer.flipX = !left;
    }

    void Update()
    {
        float direction = player.transform.position.x - transform.position.x;
        if (Mathf.Abs(direction) < 20 && player.activeSelf == true)
        {
            Attack();
        }
        else
        {
            Chill();

        }
    }
}