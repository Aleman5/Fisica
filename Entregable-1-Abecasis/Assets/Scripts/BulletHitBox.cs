using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CollisionManager;

public class BulletHitBox : MonoBehaviour, IColBox
{
    [SerializeField] Vector2 hitBoxRadius;
    [SerializeField] Elements type;

    void Start()
    {
        Instance.AddToDetector(this);
    }

    public void OnCollision()
    {

    }

    public Vector3 GetPosition()  { return transform.position; }

    public Vector2 GetBoxValues() { return hitBoxRadius; }
    
    public Elements GetTypeElem() { return type; }
}