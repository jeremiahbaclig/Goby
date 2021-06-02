using UnityEngine;
using UnityEngine.Tilemaps;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    public static float moveSpeed = 2.2f;
    public static bool isSprinting = false;
    public static bool onMobile = false;

    public Rigidbody2D rb;
    public Animator anim;
    public ParticleSystem dust;
    public ParticleSystem attack;
    public Tilemap environment;

    public AudioSource walkingSound;
    public AudioSource runningSound;
    
    Vector2 movement;

    void Update()
    {

#if UNITY_IOS || UNITY_ANDROID || UNITY_WP_8_1
        {
            movement.x = CrossPlatformInputManager.GetAxis("Horizontal");
            movement.y = CrossPlatformInputManager.GetAxis("Vertical");
            onMobile = true;
        }
#else
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
#endif
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);

        if (PauseMenu.isPaused || CutsceneManager.isCutscene || DialogueManager.isTalking)
        {
            moveSpeed = 0f;
        }
        else if (Input.GetKey(KeyCode.LeftShift) || isSprinting)
        {
            moveSpeed = 5f;
        }
        else
        {
            moveSpeed = 2.2f;
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

