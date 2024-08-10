using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDialog : MonoBehaviour
{
    [SerializeField] public GameObject dialogScene;
    // Start is called before the first frame update

    private void Awake() {
        dialogScene.SetActive(false);
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player")
        {
            dialogScene.SetActive(true);
        }
        
    }
    // public void Dialog()
    // {
    //     gameOverScreen.SetActive(true);
    // }
}
