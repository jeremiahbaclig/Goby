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
            rend.sortingOrder -= 1; // slowly hide the character

            if(rend.sortingOrder < 0)
            {
                Destroy(gameObject); // remove once bts
            }
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        dazedTime = startDazedTime; // enemies stunned
        var instant = Instantiate(blood, transform.position, Quaternion.identity); // instantiate particle
        instant.transform.parent = gameObject.transform; // set particle's parent

        gameObject.transform.Find("Health/heart" + health).SetPositionAndRotation // get heart and remove it
            (new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 100), Quaternion.identity);
        
        health -= damage;
    }

    IEnumerator InvokeMovement()
    {
        while (true)
        {
            RandomMovement();
            yield return new WaitForSeconds(2);
        }
    }
    private void RandomMovement()
    {
        float choice = UnityEngine.Random.Range(-1, 1);
        int[] valid = {-1, 1};
        int factorX = UnityEngine.Random.Range(0, 1);
        int factorY = UnityEngine.Random.Range(0, 1);
        if (health >= 3 && !PauseMenu.isPaused)
        {
            movement = new Vector2(choice * valid[factorX], choice * valid[factorY]); // where to move to

            anim.SetFloat("Horizontal", (float)Math.Round(choice));
            anim.SetFloat("Speed", (float)Math.Round(choice));

            if ((float)Math.Round(choice) < 0.1f) // if random val is < 0.5, then idle
            {
                moveSpeed = 0f;
            }
            else
            {
                moveSpeed = 2f;
            }
        }
        else if (!PauseMenu.isPaused)
        {
            int moveX = UnityEngine.Random.Range(0, 1);
            int moveY = UnityEngine.Random.Range(0, 1);
            movement = new Vector2(valid[moveX], valid[moveY]); // where to move to

            anim.SetFloat("Horizontal", (float)Math.Round(Math.Abs(choice)));
            anim.SetFloat("Speed", 1);

            moveSpeed = 3f;
        }
    }
}
