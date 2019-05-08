using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCol : Aleman5DLL.Collisions.Box
{
    [SerializeField] Vector2 hitBoxRadius;
    [SerializeField] Aleman5DLL.Collisions.Elements type;

    void Awake()
    {
        SetData(hitBoxRadius, type);
    }

    public override void OnCollision(Aleman5DLL.Collisions.Box collision)
    {
        if (collision.GetTypeElem() == Aleman5DLL.Collisions.Elements.Enemy)
        {

        }
    }
}