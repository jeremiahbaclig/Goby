using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public int health;
    private float moveSpeed;
    public Rigidbody2D rb;
    private float dazedTime;
    public float startDazedTime;
    private Vector2 movement;

    public Animator anim;
    public GameObject blood;
    private SpriteRenderer rend;

    void Start()
    {
        StartCoroutine(InvokeMovement());
    }

    void Update()
    {
        if(dazedTime <= 0)
        {
            moveSpeed = 3f;
        }
        else
        {
            moveSpeed = 0f;
            dazedTime -= Time.deltaTime;
        }
        if(health <= 0)
        {
            anim.SetFloat("Health", 0f);
            rend = gameObject.GetComponent<SpriteRenderer>();
            rend.sortingOrder -= 1;

            if(rend.sortingOrder < 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        dazedTime = startDazedTime;
        Instantiate(blood, transform.position, Quaternion.identity);
        Debug.Log("HEALTH: " + health);
        Health.RemoveHeart(health);
        health -= damage;
    }

    IEnumerator InvokeMovement()
    {
        while (true)
        {
            RandomMovement();
            yield return new WaitForSeconds(3);
        }
    }
    private void RandomMovement()
    {
        float choice = UnityEngine.Random.value;

        movement = new Vector2(choice, Math.Abs(1f - choice));

        anim.SetFloat("Horizontal", (float)Math.Round(choice));
        anim.SetFloat("Speed", (float)Math.Round(choice));

        if((float)Math.Round(choice) < 0.1f)
        {
            moveSpeed = 0;
        }
        else
        {
            moveSpeed = 3f;
        }
    }
}
