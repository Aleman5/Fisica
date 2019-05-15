using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;

    float radio = 1.0f;
    float angle = 0.0f;

    float forceX = 0.0f;
    float forceY = 0.0f;

    void Update()
    {
        Vector3 addPosition = Vector3.zero;

        if (Input.GetKey(KeyCode.S))
            forceX += Time.deltaTime;
        else if (Input.GetKey(KeyCode.X))
            forceX -= Time.deltaTime;
        else if (forceX > 0.0f)
            forceX -= Time.deltaTime;
        else if (forceX < 0.0f)
            forceX += Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
            forceY += Time.deltaTime;
        else if (Input.GetKey(KeyCode.Z))
            forceY -= Time.deltaTime;
        else if (forceY > 0.0f)
            forceY -= Time.deltaTime;
        else if (forceY < 0.0f)
            forceY += Time.deltaTime;

        addPosition = MCU();

        transform.position += addPosition;


        angle += speed * Time.deltaTime;
        if (angle >= 360.0f) angle = 0.0f;

        for (int i = 0; i < fires; i++)
        {
            Vector3 extraPos = Aleman5DLL.Physics.MCU(angle, radio * (i + 1));
            fireGameObjects[i].position = transform.position + extraPos;
        }
    }

    public Vector3 MCU(float angle, float radio, float forceX, float forceY)
    {
        Vector3 newPos = radio * Mathf.Cos(angle) * Vector3.right + radio * Mathf.Sin(angle) * Vector3.up;

        return newPos;
    }
}
