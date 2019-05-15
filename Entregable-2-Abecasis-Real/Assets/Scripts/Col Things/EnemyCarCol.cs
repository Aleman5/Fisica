using UnityEngine;

public class EnemyCarCol : Aleman5DLL.Collisions.Box
{
    [SerializeField] GameObject fire;

    public override void OnCollision(Aleman5DLL.Collisions.Box collision)
    {
        if(collision.GetTypeElem() == Aleman5DLL.Collisions.Elements.Enviroment)
        {
            Instantiate(fire, transform.position, transform.rotation, transform.parent);
            GetComponent<ObjectsMovement>().LimitReached();
        }
    }
}