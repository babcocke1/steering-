using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisonAvoider : Kinematic
{
    CollisionAvoidance myMoveType;
    CollisionAvoidance myRotateType;
    public Kinematic[] myTargets = new Kinematic[2];
    // Start is called before the first frame update
    void Start()
    {
        myMoveType = new CollisionAvoidance(myTargets, 2);
        myMoveType.character = this;
        myMoveType.normalBehaviorVelocity = this.linearVelocity;
        

        myRotateType = new CollisionAvoidance(myTargets, 2);
        myRotateType.character = this;
        
    }

    // Update is called once per frame
    protected override void Update()
    {

        steeringUpdate = new SteeringOutput();
        steeringUpdate.linear = myMoveType.getSteering().linear;
        steeringUpdate.angular = myRotateType.getSteering().angular;
        base.Update();


    }
}
