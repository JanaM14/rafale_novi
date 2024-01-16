using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life=3;
    public GameObject explosionPrefab; // Drag your explosion prefab here in the Unity Editor
    // Start is called before the first frame update
    void Awake(){
        Destroy(gameObject,life);
    }
    void OnCollisionEnter(Collision collision){
        if (collision.rigidbody && !collision.gameObject.CompareTag("Rafale"))
        {
            collision.rigidbody.useGravity = true;
        }
        Instantiate(explosionPrefab, collision.contacts[0].point, Quaternion.identity);
        FindObjectOfType<AudioManager>().Play("Explosion");
    }
}
