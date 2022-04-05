using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float spd = 2;
    private Vector2 move;
    private SpriteRenderer spriteRenderer;
    private Sprite frontsprite;
    private Sprite backsprite;
    private Sprite leftsprite;
    private Sprite rightsprite;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
    }

    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0)
        {
            spd = 1;
        }
        else
        {
            spd = 2;
        }
        rb.MovePosition(rb.position + move * spd * Time.deltaTime);
    }

    private void ChangeSprite()
    {
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            spriteRenderer.sprite = leftsprite;
        }
        else if(Input.GetAxisRaw("Horizontal") == 1)
        {
            spriteRenderer.sprite = rightsprite;
        }
        else if (Input.GetAxisRaw("Vertical") == -1)
        {
            spriteRenderer.sprite = backsprite;
        }
        else if (Input.GetAxisRaw("Vertical") == 1)
        {
            spriteRenderer.sprite = frontsprite;
        }
    }
}
