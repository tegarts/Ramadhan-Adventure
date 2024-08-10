using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float HealthAwal;
    // public float currentHealth { get; private set;}
    public float currentHealth;
    private Animator anim;
    private bool dead;

    
    private UIManager uiManager;
    public int respawnTime = 2;
    

    

    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;
    [SerializeField] AudioClip hitSound;
    [SerializeField] AudioClip dieSound;
  
    // Start is called before the first frame update
    private void Awake() {
        currentHealth = HealthAwal;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        uiManager = FindObjectOfType<UIManager>();
    }

    public void KenaDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, HealthAwal);
        
        if(currentHealth > 0)
        {
            
            anim.SetTrigger("hit");
            AudioManager.instance.PlaySound(hitSound);
            StartCoroutine(Invunerability());
           
        }
        
        else
        {
            if(!dead)
            {
                

                // anim.SetBool("grounded", true);
                anim.SetTrigger("die");
                AudioManager.instance.PlaySound(dieSound);
                GetComponent<GatherInput>().enabled = false;
                dead = true;
                
                
            }
            
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, HealthAwal);
    }

    public void Respawn()
    {
       

        if(respawnTime > 0)
        {
        dead = false;
        AddHealth(HealthAwal);
        anim.ResetTrigger("die");
        anim.Play("idle");
        StartCoroutine(Invunerability());
        GetComponent<GatherInput>().enabled = true;
        respawnTime--;
        } else{
            uiManager.GameOver();
        }
             
       
        
       
        
    }
    // public void Respawn()
    // {
    //     if(currentHealth == 2) {
    //         dead = false;
    //     // AddHealth(HealthAwal);
    //     currentHealth =2;
    //     anim.ResetTrigger("die");
    //     anim.Play("idle");
    //     StartCoroutine(Invunerability());
    //     }
    //     else {
    //          dead = false;
    //     // AddHealth(HealthAwal);
    //     currentHealth =1;
    //     anim.ResetTrigger("die");
    //     anim.Play("idle");
    //     StartCoroutine(Invunerability());
    //     }
       
        
    // }
   

    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(10,11, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10,11, false);
    }

}
