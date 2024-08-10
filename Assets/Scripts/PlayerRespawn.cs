using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioClip checkpointSound;
    private Transform currentCheckpoint;
    private Health playerHealth;
    

    private void Awake() {
        playerHealth = GetComponent<Health>();
        
    }

    public void Respawn()
    {
      
        transform.position = currentCheckpoint.position;
        
        playerHealth.Respawn(); 
        
       
        
         

        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;
            AudioManager.instance.PlaySound(checkpointSound);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("appear");
            collision.GetComponent<Animator>().SetBool("idle2", true);
        }
    }

    
}
