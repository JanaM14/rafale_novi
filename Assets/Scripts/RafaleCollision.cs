using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RafaleCollision : MonoBehaviour
{
    public RafaleController movement;
   

    void OnCollisionEnter (Collision collisionInfo) {

        //Debug.Log(collisionInfo.collider.name);
        if (movement != null && collisionInfo.collider != null)
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
