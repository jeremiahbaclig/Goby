using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public PlayerController player;

    public float attackRange;
    public int damage;
    private bool canAttack = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            player.CreateAttack();
            CameraShake.Instance.ShakeCamera(4f, 0.15f);
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
            for (int i=0; i<enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
            }
        }    
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
