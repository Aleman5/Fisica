using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;

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

        transform.position += addPosition;
    }
}
