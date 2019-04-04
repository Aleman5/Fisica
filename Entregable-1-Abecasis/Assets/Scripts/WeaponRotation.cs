using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed;

    Transform cannon;

    void Awake()
    {
        cannon = transform.GetComponentInChildren<Transform>();
    }

    void Update()
    {
        /*if (Input.GetKey(KeyCode.D) && cannon.transform.eulerAngles.z < -90.0f)
            cannon.Rotate(0.0f, 0.0f, -rotationSpeed, Space.Self);

        if (Input.GetKey(KeyCode.A) && cannon.transform.eulerAngles.z < 90.0f)
            cannon.Rotate(0.0f, 0.0f, rotationSpeed, Space.Self);*/

        if (Input.GetKey(KeyCode.D))
            cannon.Rotate(0.0f, 0.0f, -rotationSpeed, Space.Self);

        if (Input.GetKey(KeyCode.A))
            cannon.Rotate(0.0f, 0.0f, rotationSpeed, Space.Self);
    }
}
