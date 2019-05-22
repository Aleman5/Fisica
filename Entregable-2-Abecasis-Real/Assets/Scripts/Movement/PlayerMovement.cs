using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Wheel leftWheel;
    public Wheel rightWheel;
    public float speed;

    public float minY;
    public float maxY;
    public float minX;
    public float maxX;

    //float forceX = 0.0f;
    //float forceY = 0.0f;

    void Update()
    {
        float axis = Input.GetAxis("Horizontal");

        if (axis == 0)
        {
            if (Input.GetKey(KeyCode.A) && transform.position.y < maxY)
            {
                leftWheel.speed += speed * 0.5f;
                rightWheel.speed += speed * 0.5f;
                transform.position += Aleman5DLL.Physics.NextPositionMRU(
                    (rightWheel.TractionForce() + leftWheel.TractionForce()) * 0.5f, Vector3.up);
                
            }
            else
            {
                leftWheel.speed = 0.0f;
                rightWheel.speed = 0.0f;
                if (transform.position.y > minY)
                    transform.position += Aleman5DLL.Physics.NextPositionMRU(
                    speed * 0.3f, Vector3.down);
            }
        }
        else
        {
            if (axis > 0.0f)
            {
                leftWheel.speed += axis * speed * Time.deltaTime;
                transform.position += Aleman5DLL.Physics.NextPositionMRU(
                    leftWheel.TractionForce(), Vector3.up + Vector3.right);
            }
            else
            {
                rightWheel.speed += axis * speed * Time.deltaTime * -1;
                transform.position += Aleman5DLL.Physics.NextPositionMRU(
                    rightWheel.TractionForce(), Vector3.up + Vector3.left);
            }
        }
    }
}



/*void Update()
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
    }*/