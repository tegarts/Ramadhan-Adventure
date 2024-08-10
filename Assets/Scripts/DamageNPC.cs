using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageNPC : MonoBehaviour
{
    private bool _aktip = false;
    [SerializeField] private float damage;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision) {
        _aktip = false;
        if (collision.tag == "Player")
        {
           
            if(!_aktip)
            { 
                _aktip = true;
            collision.GetComponent<Health>().KenaDamage(damage);
         
           
             
            }
        }
    }
}
