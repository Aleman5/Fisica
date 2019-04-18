using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] float velocity;

    Vector2 adaptedVelocity;
    float time;
    const float gravity = 9.81f;

    void Awake()
    {
        time = 0.0f;
    }

    void Update()
    {
        time += Time.deltaTime;

        float x = adaptedVelocity.x * Time.deltaTime;
        float y = adaptedVelocity.y * Time.deltaTime - gravity * Mathf.Sqrt(time) * 0.5f * Time.deltaTime;

        transform.position += new Vector3(x, y, 0.0f);
    }

    public void CalculateVelocity(float degrees, float charge)
    {
        charge += 0.5f;

        adaptedVelocity.x = charge * velocity * Mathf.Cos(degrees * Mathf.Deg2Rad);
        adaptedVelocity.y = charge * velocity * Mathf.Sin(degrees * Mathf.Deg2Rad);
    }
}