using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAvoidance : SteeringBehavior
{
    public Kinematic[] targets = new Kinematic[2];
    public Kinematic character;
    public float radius = 1f;
    public float maxAcceleration =1f;
    public Vector3 normalBehaviorVelocity;
    public CollisionAvoidance(Kinematic[] newTargets, int count)
    {
        for(int i = 0; i<count; i++)
        {
            targets[i] = newTargets[i];
        }
    }
    public override SteeringOutput getSteering()
    {
        float shortestTime = Mathf.Infinity;
        Kinematic firstTarget = null;
        float firstMinSeperation = Mathf.Infinity; 
        float firstDistance = Mathf.Infinity;
        Vector3 firstRelativePos = Vector3.positiveInfinity;
        Vector3 firstRelativeVel = new Vector3(0, 0, 0);
        Vector3 relativePos;
        Vector3 relativeVel;
        float relativeSpeed;
        float timeToCollision = 0;
        float distance = 0;
        float minSeparation;
        Vector3 futureCollision;
        foreach (Kinematic t in targets)
        {

            relativePos = t.transform.position - character.transform.position;
            relativeVel = character.linearVelocity - t.linearVelocity;
            relativeSpeed = relativeVel.magnitude;
            timeToCollision = Vector3.Dot(relativePos, relativeVel) / (relativeSpeed * relativeSpeed);
            


            distance = relativePos.magnitude;
            minSeparation = distance - relativeSpeed * shortestTime;
            //checks for collision
            if (minSeparation < 2 * radius)
            {
                // Check if it is the shortest
                if (timeToCollision > 0 && timeToCollision < shortestTime)
                {
                    // overwrite the time, target and other data
                    shortestTime = timeToCollision;
                    firstTarget = t;
                    firstMinSeperation = minSeparation;
                    firstDistance = distance;
                    firstRelativePos = relativePos;
                    firstRelativeVel = relativeVel;
                }
            }
        }
        if (firstTarget == null) {
            SteeringOutput result0 = new SteeringOutput();
            result0.linear = character.linearVelocity - normalBehaviorVelocity;
            result0.angular = Mathf.Atan2(result0.linear.x, result0.linear.y);
        }
        if (firstMinSeperation > 0 && firstDistance < 2 * radius) {

            futureCollision = character.transform.position + timeToCollision *  character.linearVelocity;
            relativePos = futureCollision - firstTarget.transform.position;
            //float temp;
            //temp = relativePos.x;
            //relativePos.x = relativePos.z;
            //relativePos.z = temp;

        }
        else {
            relativePos = firstRelativePos + firstRelativeVel * shortestTime;
        }
        SteeringOutput result = new SteeringOutput();
        relativePos.Normalize();
        result.linear = relativePos *  maxAcceleration;
        result.angular = Mathf.Atan2(result.linear.x, result.linear.y);
        return result;
        
    }
    
}
