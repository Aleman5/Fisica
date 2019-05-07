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
            addPosition.x = Aleman5DLL.Physics.NextPositionMRU(speed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            addPosition.x = Aleman5DLL.Physics.NextPositionMRU(-speed);
        }

        t.position += addPosition;
    }
}
