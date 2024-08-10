using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMushola0 : MonoBehaviour
{
     [SerializeField] public GameObject NextScreen;
     [SerializeField] private AudioClip NextSound;

   
    private void Awake() {
       
        NextScreen.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "Player")
        {
        NextScreen.SetActive(true);
        AudioManager.instance.PlaySound(NextSound);
        
    }

        }
     
}
