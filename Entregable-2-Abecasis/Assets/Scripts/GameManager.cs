using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Aleman5DLL.Collisions.CollisionManager colMng;

    void Awake()
    {
        colMng = Aleman5DLL.Collisions.CollisionManager.Instance;

        colMng.SetRelation((int)Aleman5DLL.Collisions.Elements.Player, (int)Aleman5DLL.Collisions.Elements.Enemy);
    }

    void Update()
    {
        //colMng.Update();
    }
}
