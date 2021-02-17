using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoidance : Seek
{
    public float avoidDistance = 1f;
    public float lookDistance = 10f;
    Vector3 rightWhisker;
    Vector3 leftWhisker;
    Vector3 result;

    protected override Vector3 getTargetPosition()

    {
        RaycastHit hit;
        if (Physics.Raycast(character.transform.position, character.linearVelocity, out hit, lookDistance))
        {
            Debug.DrawRay(character.transform.position, character.linearVelocity.normalized * hit.distance, Color.red, 0.5f);
            Debug.Log("Hit " + hit.collider);
            Debug.DrawRay(character.transform.position, rightWhisker.normalized * hit.distance, Color.green, 0.5f);
            Debug.Log("WhiskerHit " + hit.collider);
            Debug.DrawRay(character.transform.position, leftWhisker.normalized * hit.distance, Color.green, 0.5f);
            Debug.Log("WhiskerHit " + hit.collider);
            rightWhisker = new Vector3(character.linearVelocity.x * Mathf.Cos(30 * Mathf.Deg2Rad) - character.linearVelocity.z * Mathf.Sin(30 * Mathf.Deg2Rad),
                                       0,
                                       character.linearVelocity.x * Mathf.Sin(30 * Mathf.Deg2Rad) + character.linearVelocity.z * Mathf.Cos(30 * Mathf.Deg2Rad));
            leftWhisker = new Vector3(character.linearVelocity.x * Mathf.Cos(-30 * Mathf.Deg2Rad) - character.linearVelocity.z * Mathf.Sin(-30 * Mathf.Deg2Rad),
                                      0,
                                      character.linearVelocity.x * Mathf.Sin(-30 * Mathf.Deg2Rad) + character.linearVelocity.z * Mathf.Cos(-30 * Mathf.Deg2Rad));
            result = hit.point + (hit.normal * avoidDistance);
            if (Physics.Raycast(character.transform.position, rightWhisker, out hit, 1f))
            {
                //Debug.DrawRay(character.transform.position, rightWhisker.normalized * hit.distance, Color.green, 0.5f);
                Debug.Log("WhiskerHit " + hit.collider);
                return hit.point + (leftWhisker.normalized * avoidDistance);
            }
            if (Physics.Raycast(character.transform.position, leftWhisker, out hit, 1f))
            {
               // Debug.DrawRay(character.transform.position, leftWhisker.normalized * hit.distance, Color.green, 0.5f);
                Debug.Log("WhiskerHit " + hit.collider);
                return hit.point + (rightWhisker.normalized * avoidDistance);
            }
            return result;
        }

        else return base.getTargetPosition();
    }

}
