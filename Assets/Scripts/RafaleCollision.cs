using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RafaleCollision : MonoBehaviour
{
    public RafaleController movement;
   
    public GameObject explosionPrefab;

    void OnCollisionEnter (Collision collisionInfo) {

        //Debug.Log(collisionInfo.collider.name);
        if (movement != null && collisionInfo.collider != null)
        {
            movement.enabled = false;
            Instantiate(explosionPrefab, collisionInfo.contacts[0].point, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("Explosion");
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
