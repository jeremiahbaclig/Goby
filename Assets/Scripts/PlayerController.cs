using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 4f;
    public Rigidbody2D rb;
    public Animator anim;
    public ParticleSystem dust;
    public ParticleSystem attack;
    public Tilemap environment;
    Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 6f;
        }
        else
        {
            moveSpeed = 3f;
        }

    }
    
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if (moveSpeed > 4f)
        {
            CreateDust();
        }
    }

    public void CreateDust()
    {
        dust.Play();
    }

    public void CreateAttack()
    {
        attack.Play();
    }
}

