using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollect : MonoBehaviour
{
    private bool _collected = false;
    [SerializeField] public float healthValue;
    [SerializeField] private AudioClip healtSound;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision) {
        
        if(collision.tag == "Player")
        {
             if(!_collected)
            {
                _collected = true;
            AudioManager.instance.PlaySound(healtSound);
            collision.GetComponent<Health>().AddHealth(healthValue);
            gameObject.SetActive(false);
            
             }
        }
    }
}
