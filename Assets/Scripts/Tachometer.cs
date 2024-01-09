// Tachometer Script
using UnityEngine;

public class Tachometer : MonoBehaviour
{
    public Rigidbody airplaneRigidbody;
    public RectTransform needleTransform;
    public float maxRPM = 3000;
    public float needleRotationSpeed = 5f;
    private Vector3 previousPosition;
    public float dampingFactor = 5f;  // Adjust this value for the desired damping effect


    private void Start()
    {
        // Initialize previousPosition at the start
        previousPosition = airplaneRigidbody.position;
    }

   private float currentRPM;  // Add a member variable to store the current RPM

    private void Update()
    {
        if (airplaneRigidbody != null)
        {
            float linearSpeed = Vector3.Distance(previousPosition, airplaneRigidbody.position) / Time.deltaTime;

            // Smoothly update the current RPM
            currentRPM = Mathf.Lerp(currentRPM, MapSpeedToRPM(linearSpeed), Time.deltaTime * dampingFactor);

            RotateNeedle(currentRPM);

            // Update previous position for the next frame
            previousPosition = airplaneRigidbody.position;
        }
    }


    private float MapSpeedToRPM(float speed)
{
    // Adjust this scaling factor based on your desired relationship between speed and RPM
    float scalingFactor = 10f;  // Experiment with this value to achieve the desired RPM at a given speed

    // Map the linear speed to an RPM value
    return speed * scalingFactor;
}



    private void RotateNeedle(float currentRPM)
{
    float rotationAngle = Mathf.Lerp(140f, -140f, currentRPM / maxRPM);
    needleTransform.rotation = Quaternion.Slerp(needleTransform.rotation, Quaternion.Euler(0, 0, rotationAngle), Time.deltaTime * needleRotationSpeed);
}

}
