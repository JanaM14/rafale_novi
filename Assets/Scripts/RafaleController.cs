using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RafaleController : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 100; 

    public float FlySpeed = 0.0f;
    public float YawAmount = 100;
    private float Yaw;
    private Rigidbody rb;
    float initialAcceleration = 60f;  
    float regularAcceleration = 30f; 
    float deceleration = 20f;         
    float maxInitialSpeed = 200;
    float maxSpeed = 340; 
    private float currentMSL;
    public float CurrentMSL
    {
        get { return currentMSL; }
    }
    public int fuelCapacity = 5000;
    public float fuelBurnRate = 1800f;
    private float currentFuel;

    public float UpdateFuel()
{
    float timeElapsed = Time.deltaTime;  
    float engineEfficiency = 0.95f;  

    float currentBurn = fuelBurnRate * engineEfficiency * timeElapsed / 3600f;
    currentFuel -= currentBurn;
    float total = fuelCapacity+currentFuel;
    total = Mathf.Max(0, total);

    return total;
}

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        FindObjectOfType<AudioManager>().Play("Airplane");

    }

    void Update()
    {
         
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Yaw += horizontalInput * YawAmount * Time.deltaTime;
        float pitch = Mathf.Lerp(0, 30, Mathf.Abs(verticalInput)) * Mathf.Sign(verticalInput);
        float roll = Mathf.Lerp(0, 30, Mathf.Abs(horizontalInput)) * -Mathf.Sign(horizontalInput);

        Quaternion rotation = Quaternion.Euler(Vector3.up * Yaw);
        Quaternion pitchRotation = Quaternion.Euler(Vector3.left * pitch);
        Quaternion rollRotation = Quaternion.Euler(Vector3.forward * roll);

        transform.localRotation = rotation * pitchRotation * rollRotation;

        // Bullets
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;

            FindObjectOfType<AudioManager>().Play("Bullet");
        }

      
        if (Input.GetKey(KeyCode.X))  // ubrzaj
        {
            if (FlySpeed < maxInitialSpeed)
            {
                FlySpeed += initialAcceleration * Time.deltaTime;
            }
            else
            {
                FlySpeed += regularAcceleration * Time.deltaTime;
            }

            FlySpeed = Mathf.Clamp(FlySpeed, 0, maxSpeed);
            UpdateFuel();
        }
        else if (Input.GetKey(KeyCode.C))  //uspori
        {
            FlySpeed -= deceleration * Time.deltaTime;
            FlySpeed = Mathf.Clamp(FlySpeed, 0, maxSpeed);
        }

        transform.position += transform.forward * FlySpeed * Time.deltaTime;

        FindObjectOfType<AltimeterConverter>().Altimeter();
        currentMSL = transform.position.y- 86;

        SpeedConverter.ShowSpeed(FlySpeed, 0, maxSpeed);

        FindObjectOfType<Fuel>().FuelConverter();

    }
}


