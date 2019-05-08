using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;

    SpriteRenderer sprRend;
    bool direction = false;

    void Awake()
    {
        sprRend = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 addPosition = Vector3.zero;

        // MRU
        if (Input.GetKey(KeyCode.S))
        {
            addPosition.x = Aleman5DLL.Physics.NextPositionMRU(speed);
            if(direction)
            {
                sprRend.flipX = false;
                direction = false;
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            addPosition.x = Aleman5DLL.Physics.NextPositionMRU(-speed);
            if(!direction)
            {
                sprRend.flipX = true;
                direction = true;
            }
        }

        transform.position += addPosition;
    }
}
