using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    [SerializeField] Transform bullet;

    Transform parent;

    private void Awake()
    {
        parent = GetComponentInParent<Transform>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Transform t = Instantiate(bullet, null).transform;
            t.eulerAngles += transform.eulerAngles;

            t.GetComponent<BulletMovement>().CalculateVelocity(transform.eulerAngles.z);
        }
    }
}
