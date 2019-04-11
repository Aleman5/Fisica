using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] float velocity;

    Vector2 adaptedVelocity;

    float time;


    Vector2 pos;

    const float gravity = 9.81f;

    private void Awake()
    {
        time = 0.0f;
        pos = new Vector2();
    }

    void Update()
    {
        time += Time.deltaTime;

        //float speedY = (adaptedVelocity.y * Time.deltaTime - gravity * Mathf.Sqrt(Time.deltaTime) * 0.5f) * Time.deltaTime;
        pos.x += adaptedVelocity.x * Time.deltaTime;
        pos.y += (adaptedVelocity.y * Time.deltaTime - gravity * Mathf.Sqrt(Time.deltaTime) * 0.5f);

        Vector3 v = new Vector3(pos.x, pos.y, 0.0f);

        transform.position = v;

        /*transform.Translate(
            adaptedVelocity.x * Time.deltaTime, // MRU
            speedY, // Tiro Vertical + Caida Libre
            0.0f);*/

        //Debug.Log(speedY);
    }

    public void CalculateVelocity(float degrees)
    {
        adaptedVelocity.x = velocity * Mathf.Cos(degrees);
        adaptedVelocity.y = velocity * Mathf.Sin(degrees);

        //GetComponentInChildren<Transform>().rotation = rotation;

        //Debug.Log("Velocity x: " + adaptedVelocity.x + " y: " + adaptedVelocity.y);
    }
}