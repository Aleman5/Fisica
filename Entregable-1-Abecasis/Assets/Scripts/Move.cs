using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float speed;

    Transform t;

    void Awake()
    {
        t = GetComponent<Transform>();
    }

    void Update()
    {
        Vector3 addPosition = Vector3.zero;

        // MRU
        if (Input.GetKey(KeyCode.S))
        {
            addPosition.x = speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            addPosition.x = -speed * Time.deltaTime;
        }

        t.position += addPosition;
    }
}
