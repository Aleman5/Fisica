using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] float velocity;

    Vector2 adaptedVelocity;

    float time;

    const float gravity = 9.81f;

    private void Awake()
    {
        time = 0.0f;
    }

    void Update()
    {
        time += Time.deltaTime;

        float speedY = (adaptedVelocity.y + (-gravity * Mathf.Sqrt(time)) / 2) * Time.deltaTime;

        transform.Translate(
            adaptedVelocity.x * Time.deltaTime, // MRU
            speedY, // Tiro Vertical + Caida Libre
            0.0f);

        Debug.Log(speedY);
    }

    public void CalculateVelocity(float degrees)
    {
        // Calculate based on the angle ofthe z axis

        adaptedVelocity.x = -velocity * Mathf.Cos(degrees);
        adaptedVelocity.y = velocity * Mathf.Sin(degrees);

        //Debug.Log("Velocity x: " + adaptedVelocity.x + " y: " + adaptedVelocity.y);
    }
}
