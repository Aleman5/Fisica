using UnityEngine;

public class Throw : MonoBehaviour
{
    [SerializeField] Transform bullet;
    [SerializeField] Transform origPos;

    Transform parent;

    void Awake()
    {
        parent = GetComponentInParent<Transform>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Transform t = Instantiate(bullet, origPos.position, Quaternion.identity).transform;

            t.eulerAngles += transform.eulerAngles;

            t.GetComponent<BulletMovement>().CalculateVelocity(transform.eulerAngles.z + 90.0f);
        }
    }
}
