using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Wheel leftWheel;
    public Wheel rightWheel;
    public float speed;
    public float acceleration;
    public float friction;

    public float minY;
    public float maxY;
    public float minX;
    public float maxX;

    void Update()
    {
        float deltaT = Time.deltaTime;

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.Z)){
            if (Input.GetKey(KeyCode.A))
                leftWheel.speed += acceleration * deltaT;
            if (Input.GetKey(KeyCode.Z))
                leftWheel.speed -= acceleration * deltaT;
        }
        else if(leftWheel.speed != 0){
            leftWheel.speed = Mathf.Lerp(leftWheel.speed, 0, friction);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.C)){
            if (Input.GetKey(KeyCode.D))
                rightWheel.speed += acceleration * deltaT;
            if (Input.GetKey(KeyCode.C))
                rightWheel.speed -= acceleration * deltaT;
        }
        else if (rightWheel.speed != 0){
            rightWheel.speed = Mathf.Lerp(rightWheel.speed, 0, friction );
        }

        if (leftWheel.TractionForce() == rightWheel.TractionForce()){
                transform.position += Aleman5DLL.Physics.NextPositionMRU(rightWheel.TractionForce(), Vector3.up);
        }else if(leftWheel.TractionForce() > rightWheel.TractionForce()){
                transform.position += Aleman5DLL.Physics.NextPositionMRU(leftWheel.TractionForce() + rightWheel.TractionForce(),
                                                                        Vector3.up + Vector3.left);
        }
        else if (leftWheel.TractionForce() < rightWheel.TractionForce()){
            transform.position += Aleman5DLL.Physics.NextPositionMRU(rightWheel.TractionForce() + leftWheel.TractionForce(),
                                                                    Vector3.up + Vector3.right);
        }
        if (transform.position.y > 0 && leftWheel.TractionForce() == 0 && rightWheel.TractionForce() == 0) { 
            transform.position += Aleman5DLL.Physics.NextPositionMRU(acceleration, Vector3.down);
        }

    }

    /*void Update()
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
    }*/
}

