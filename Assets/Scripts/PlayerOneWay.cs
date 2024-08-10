using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneWay : MonoBehaviour
{
    private GameObject currentOneWayPlatform;

    [SerializeField] private CapsuleCollider2D playerCollider1;
    // [SerializeField] private CapsuleCollider2D playerCollider2;
    [SerializeField] private BoxCollider2D playerCollider3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(currentOneWayPlatform != null)
            {
                StartCoroutine(DisableCollision());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        
        if(collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneWayPlatform = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        
        if(collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneWayPlatform = null;
        }
    }

    private IEnumerator DisableCollision()
    {
        Collider2D platformCollider = currentOneWayPlatform.GetComponent<Collider2D>();
        

        Physics2D.IgnoreCollision(playerCollider1, platformCollider);
        // Physics2D.IgnoreCollision(playerCollider2, platformCollider);
        Physics2D.IgnoreCollision(playerCollider3, platformCollider);
        yield return new WaitForSeconds(0.25f);
        Physics2D.IgnoreCollision(playerCollider1, platformCollider, false);
        // Physics2D.IgnoreCollision(playerCollider2, platformCollider, false);
        Physics2D.IgnoreCollision(playerCollider3, platformCollider, false);
    }
}

