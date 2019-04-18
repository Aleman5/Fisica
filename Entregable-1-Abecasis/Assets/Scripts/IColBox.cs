using UnityEngine;
using static CollisionManager;

public interface IColBox
{
    void OnCollision();
    Vector3 GetPosition();
    Vector2 GetBoxValues();
    Elements GetTypeElem();
}