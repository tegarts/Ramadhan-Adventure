using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
   public GameObject player;
    private Vector3 initScale;

    public bool flip;
  
    public float speed;
    float maxDist = 7;
    float minDist = 3;
    [SerializeField] private Animator anim;



    [SerializeField] private Transform LeftEdge;
    [SerializeField] private Transform RightEdge;
     private bool movingLeft;
   
   
    // Start is called before the first frame update
   
    private void Awake()
    {
        initScale = transform.localScale;
    }
    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {
       Vector3 scale = transform.localScale;

        if(Vector3.Distance(transform.position, player.transform.position) <= maxDist)
        { 
            anim.SetBool("isAttacking", false);
        if(player.transform.position.x > transform.position.x){

            scale.x = Mathf.Abs(scale.x) * -1 * (flip ? 1 : -1);
            transform.Translate(speed * Time.deltaTime, 0, 0);
        } else {
            scale.x = Mathf.Abs(scale.x) * (flip ? 1 : -1);
            transform.Translate(speed * Time.deltaTime * -1, 0, 0);
        }

        if(Vector3.Distance(transform.position, player.transform.position) <= minDist)
        {
           anim.SetBool("isAttacking", true);
           
        }
        transform.localScale = scale;
     }
     else{
         if(movingLeft)
        {
            if(transform.position.x >= LeftEdge.position.x)
            MoveInDirection(-1);
            else
            DirectionChange();
            
        } else {
            if(transform.position.x <= RightEdge.position.x)
            MoveInDirection(1);
            else
            DirectionChange();
        }

     }
    
    }

    private void MoveInDirection(int _direction)
    {

        transform.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);

        transform.position = new Vector3(transform.position.x + Time.deltaTime * _direction * speed, transform.position.y, transform.position.z);
    }


    private void DirectionChange()
    {
        movingLeft = !movingLeft;
    }

   
   
}
