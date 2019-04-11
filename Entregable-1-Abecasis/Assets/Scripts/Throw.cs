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
            Transform tform = Instantiate(bullet, transform.position, Quaternion.identity).transform;

            tform.position = transform.position;

            //tform.eulerAngles += transform.eulerAngles;
            
            Debug.Log(parent.eulerAngles.z);

            tform.GetComponent<BulletMovement>().CalculateVelocity(parent.eulerAngles.z);
        }
    }
}
