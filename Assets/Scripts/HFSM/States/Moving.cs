using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : Grounded
{
    
    private float _horizontalInput; // ----->

    public Moving(MovementSM stateMachine) : base("Moving", stateMachine) 
    {
      
    }

    public override void Enter()
    {
        base.Enter();
        _horizontalInput = 0f;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _horizontalInput = Input.GetAxisRaw("Horizontal"); // ----_>

       if (Mathf.Abs(_horizontalInput) < Mathf.Epsilon)
        stateMachine.ChangeState(_sm.idleState);

        
    }

     public override void UpdatePhysics()
    {
        base.UpdatePhysics();
       Vector2 vel = _sm.rb.velocity;
       vel.x = _horizontalInput * _sm.speed;
       _sm.rb.velocity = vel;
    }
}
