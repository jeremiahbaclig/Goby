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
    private Waypoints waypoint;
    private int waypointIndex;

    void Start()
    {
        waypoint = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();

        
        for(int i=0; i < waypoint.waypoints.Length - 1; i++)
        {
            Vector2 current = waypoint.waypoints[i].position;
            if (Vector2.Distance(rb.position, current) < 1f)
            {
                waypointIndex = i;
                Debug.Log("Ghost [" + gameObject.name + "] index at " + waypointIndex);
                break;
            }
        }
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

        if(Vector2.Distance(rb.position, waypoint.waypoints[waypointIndex].position) < 1f)
        {
            if(waypointIndex < waypoint.waypoints.Length - 1)
            {
                int half = UnityEngine.Random.Range(0, 2);
                int moving = UnityEngine.Random.Range(0, 2);

                if (half == 0)
                {
                    // stay at position
                }
                else
                {
                    if (moving == 1)
                    {
                        waypointIndex++;
                    }
                    else if (waypointIndex != 0)
                    {
                        waypointIndex--;
                    }
                    else
                    {
                        waypointIndex++;
                    }
                    
                }
            }
        }
    }

    private void FixedUpdate()
    {
        movement = waypoint.waypoints[waypointIndex].position;
        rb.position = Vector2.MoveTowards(rb.position, movement, moveSpeed * Time.deltaTime);
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
}
