using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life=3;
    public GameObject explosionPrefab; 
    void Awake(){
        Destroy(gameObject,life);
    }
    void OnCollisionEnter(Collision collision){
        if (collision.rigidbody && !collision.gameObject.CompareTag("Player"))
        {
            collision.rigidbody.useGravity = true;
            Instantiate(explosionPrefab, collision.contacts[0].point, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("Explosion");
        }
        
    }
}
