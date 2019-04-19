using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CollisionManager;

public class BulletHitBox : MonoBehaviour, IColBox
{
    [SerializeField] Vector2 hitBoxRadius;

    Elements type;

    void Start()
    {
        Instance.AddToDetector(this);
    }

    public void OnCollision()
    {
        Transform trail = transform.GetComponentInChildren<Transform>();
        trail.SetParent(null);
        trail.gameObject.AddComponent<AutoDestroy>();

        Destroy(gameObject);
    }

    public void SetTypeElem(Elements type) { this.type = ++type; }

    public Vector3 GetPosition()  { return transform.position; }

    public Vector2 GetBoxValues() { return hitBoxRadius; }
    
    public Elements GetTypeElem() { return type; }
}