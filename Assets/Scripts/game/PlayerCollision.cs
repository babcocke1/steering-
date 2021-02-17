using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("level over");
        if (collision.collider.tag == "Obstacle") 
        {
            Debug.Log("level over");
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }

}
