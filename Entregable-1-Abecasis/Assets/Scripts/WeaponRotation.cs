using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed;

    Transform cannon;

    float actualRotation;

    void Awake()
    {
        actualRotation = 0.0f;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D) && actualRotation < 90.0f)
        {
            transform.Rotate(0.0f, 0.0f, -rotationSpeed, Space.Self);
            actualRotation += rotationSpeed;

            if (actualRotation > 90.0f) actualRotation = 90.0f;
        }

        if (Input.GetKey(KeyCode.A) && actualRotation > -90.0f)
        {
            transform.Rotate(0.0f, 0.0f,  rotationSpeed, Space.Self);
            actualRotation -= rotationSpeed;

            if (actualRotation < -90.0f) actualRotation = -90.0f;
        }
    }

    public float GetActualRotation()
    {
        return actualRotation;
    }
}
