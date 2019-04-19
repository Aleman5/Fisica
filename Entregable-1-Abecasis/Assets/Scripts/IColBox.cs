using UnityEngine;
using static CollisionManager;

public interface IColBox
{
    void OnCollision();
    void SetTypeElem(Elements type);
    Vector3 GetPosition();
    Vector2 GetBoxValues();
    Elements GetTypeElem();
}