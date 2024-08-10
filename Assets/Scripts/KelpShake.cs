using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KelpShake : MonoBehaviour
{
    public GameObject pelurukelp;

    private float jarakPlayer;
    public float waktuJeda, shootSpeed;
    
    private bool bisaTembak;
   

    
    
    // Start is called before the first frame update
    void Start()
    {
        bisaTembak = true;
    }

    // Update is called once per frame
    void Update()
    {
        // if(player.transform.position.x  transform.position.x )
        if(bisaTembak == true)
        StartCoroutine(Tembak());
        
        // jarakPlayer = Vector2.Distance(transform.position, player.position);

        // if(jarakPlayer <= range && bisaTembak == true)
        // {
        //     StartCoroutine(Tembak());
        // }

        // if(Input.GetKeyDown(KeyCode.Space))
        // {
        //     Instantiate(pelurukelp, transform.position,pelurukelp.transform.rotation);
        // }
    }

    // private void OnTriggerStay2D(Collider2D Coplayer) {
    //     if(Coplayer.tag == "Player" && bisaTembak == true) {
    //         {
    //             StartCoroutine(Tembak());
              
    //         }
    //     }
    // }

    IEnumerator Tembak(){
        bisaTembak = false;
        yield return new WaitForSeconds(waktuJeda);
         Instantiate(pelurukelp, transform.position, transform.rotation);

        // peluruu.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * Time.fixedDeltaTime, 0f);
        bisaTembak = true;
    }
}
