using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : BaseState
{
    protected MovementSM _sm;
    private bool _grounded;
    private int _groundLayer = 1 << 6;
    public float moveVertical;

    
    public Jumping(MovementSM stateMachine) : base("Jumping", stateMachine) 
    {
        _sm = (MovementSM)stateMachine;
    }
    public override void Enter()
    {
        base.Enter();
       
        Vector2 vel = _sm.rb.velocity;
        vel.y += _sm.jumpForce;
        _sm.rb.velocity = vel;
       
    }
        
    //  rb.AddForce(new Vector2(0f, moveVertical * _sm.jumpForce), ForceMode2D.Impulse);
        // stateMachine.ChangeState(_sm.movingState);
    

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if(_grounded)
        {
         
        stateMachine.ChangeState(_sm.idleState);
        
        }
       
        

        
    }
    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        _grounded = _sm.rb.velocity.y < Mathf.Epsilon && _sm.rb.IsTouchingLayers(_groundLayer);
       
        
    }

    
}
