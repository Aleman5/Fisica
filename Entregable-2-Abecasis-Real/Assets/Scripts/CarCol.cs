using UnityEngine;
using UnityEngine.SceneManagement;

public class CarCol : Aleman5DLL.Collisions.Box
{
    public override void OnCollision(Aleman5DLL.Collisions.Box collision)
    {
        if (collision.GetTypeElem() == Aleman5DLL.Collisions.Elements.Enemy
         || collision.GetTypeElem() == Aleman5DLL.Collisions.Elements.Enviroment)
            SceneManager.LoadScene(0);
    }
}