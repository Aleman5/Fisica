using UnityEngine;

public class Wheel : MonoBehaviour
{
    public float angVelocity = 0.0f;
    public float speed = 1.0f;
    public float maxSpeed = 10.0f;
    public float maxAngVel = 10.0f;

    float radius = 2.0f;
    float angleI = 0.0f;
    float timeI = 0.0f;
    float angleF = 0.0f;
    float timeF = 0.0f;

    void Update()
    {
        angleI += speed * Time.deltaTime;
        timeI += Time.deltaTime;
        angVelocity = Aleman5DLL.Physics.CalculateAngularVelocity(angleI, angleF, timeI, timeF);
        angleF += speed * Time.deltaTime;
        timeF += Time.deltaTime;
        speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);
        angVelocity = Mathf.Clamp(angVelocity, -maxAngVel, maxAngVel);
    }

    public float TractionForce()
    {
        return angVelocity / radius;
    }
}
