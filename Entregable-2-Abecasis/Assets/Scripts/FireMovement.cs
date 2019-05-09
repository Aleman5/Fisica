using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int fires;
    [SerializeField] GameObject fire;

    List<Transform> fireGameObjects;

    float radio = 1.0f;
    float angle = 0.0f;

    private void Awake()
    {
        fireGameObjects = new List<Transform>();

        for (int i = 0; i < fires; i++)
            fireGameObjects.Add(Instantiate(fire, transform).transform);
    }

    void Update()
    {
        angle += speed * Time.deltaTime;
        if (angle >= 360.0f) angle = 0.0f;

        for (int i = 0; i < fires; i++)
        {
            Vector3 extraPos = Aleman5DLL.Physics.MCU(angle, radio * (i+1));
            fireGameObjects[i].position = transform.position + extraPos;
        }
    }
}
