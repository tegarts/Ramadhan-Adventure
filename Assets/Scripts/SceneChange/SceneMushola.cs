using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMushola : MonoBehaviour
{
    
     
    // Start is called before the first frame updateo
    private void Awake() {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // private void OnTriggerEnter2D(Collider2D collision) {
    //      if (collision.tag == "Player")
    //     {
         
    //         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //     }
    // }

    public void NextStage()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    

}
