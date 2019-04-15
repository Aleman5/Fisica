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
            Transform t = Instantiate(bullet, parent.position, Quaternion.identity).transform;

            //t.position = transform.position;

            //tform.eulerAngles += transform.eulerAngles;

            //Debug.Log(parent.eulerAngles.z);

            WeaponRotation wR = parent.GetComponent<WeaponRotation>();

            t.GetComponent<BulletMovement>().CalculateVelocity(wR.GetActualRotation());
        }
    }
}
