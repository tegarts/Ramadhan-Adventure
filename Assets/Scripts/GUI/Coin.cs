using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value;
    private bool _collected = false;
    [SerializeField] AudioClip CoinCollect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            if(!_collected)
            {
            AudioManager.instance.PlaySound(CoinCollect);
            _collected = true;
            Destroy(gameObject);
            
            CoinCounter.instance.IncreaseCoins(value);
             }
        }
    }
}
