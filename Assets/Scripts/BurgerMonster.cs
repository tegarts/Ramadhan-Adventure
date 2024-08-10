using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerMonster : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float attackCooldown;
    [SerializeField] private int damage;
    [SerializeField] private int range;
    [SerializeField] private int colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;
    
    [SerializeField] private Animator anim;

    private Health playerHealth;
    private burgerMovement patrol;

    private void Awake() {
        anim = GetComponent<Animator>();
        patrol = GetComponentInParent<burgerMovement>();
    }

    private void Update() {
        cooldownTimer += Time.deltaTime;

    if(PlayerInSight())
    {
        if (cooldownTimer >= attackCooldown)
        {
                cooldownTimer = 0;
                anim.SetTrigger("attack");
        }
    }

    if(patrol != null)
        patrol.enabled = !PlayerInSight();
        
    }

    private bool PlayerInSight()
    {
        
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
        0,Vector2.left, 0, playerLayer);

        if (hit.collider != null)
        playerHealth = hit.transform.GetComponent<Health>();

        return hit.collider != null;

        
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if (PlayerInSight())
        {
            playerHealth.KenaDamage(damage);
        }
    }
}
