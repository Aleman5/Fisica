using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Awake()
    {
        Aleman5DLL.Collisions.CollisionManager colMng = Aleman5DLL.Collisions.CollisionManager.Instance;

        colMng.SetRelation((int)Aleman5DLL.Collisions.Elements.Player, (int)Aleman5DLL.Collisions.Elements.Enemy);
        colMng.SetRelation((int)Aleman5DLL.Collisions.Elements.Player, (int)Aleman5DLL.Collisions.Elements.Enviroment);
        colMng.SetRelation((int)Aleman5DLL.Collisions.Elements.Enemy, (int)Aleman5DLL.Collisions.Elements.Enviroment);
    }
}
