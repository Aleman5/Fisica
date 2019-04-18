using UnityEngine;

public class Throw : MonoBehaviour
{
    public enum TankStates
    {
        Moving = 0,
        Charging,
        Count
    }

    [SerializeField] Transform bullet;
    [SerializeField] Transform origPos;
    [SerializeField] float chargingSpeed;

    Transform parent;
    TankStates state;
    float actualCharge;
    bool chargeDischarge;
    float timePassed;

    void Awake()
    {
        parent = GetComponentInParent<Transform>();
        state = TankStates.Moving;
        chargeDischarge = true;
    }

    void Update()
    {
        switch (state)
        {
            case TankStates.Moving:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    parent.GetComponentInParent<Move>().enabled = false;
                    parent.GetComponent<WeaponRotation>().enabled = false;

                    state = TankStates.Charging;
                }
                break;

            case TankStates.Charging:
                if (chargeDischarge)
                {
                    actualCharge += chargingSpeed * Time.deltaTime;
                    if (actualCharge >= 100.0f) chargeDischarge = false;
                }
                else
                {
                    actualCharge -= chargingSpeed * Time.deltaTime;
                    if (actualCharge <= 1.0f) chargeDischarge = true;
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Transform t = Instantiate(bullet, origPos.position, Quaternion.identity).transform;
                    t.eulerAngles += transform.eulerAngles;
                    t.GetComponent<BulletMovement>().CalculateVelocity(transform.eulerAngles.z + 90.0f, GetActualCharge());

                    parent.GetComponentInParent<Move>().enabled = true;
                    parent.GetComponent<WeaponRotation>().enabled = true;

                    chargeDischarge = true;
                    actualCharge = 1.0f;

                    state = TankStates.Moving;
                }
                break;
        }
    }

    /// <summary>
    /// Returns the actual charging value. min: 0.01f max: 1.0f
    /// </summary>
    /// <returns>Charging value</returns>
    public float GetActualCharge() { return actualCharge * 0.01f; }

    public TankStates TankState
    {
        get { return state; }
        set { state = value; }
    }
}
