using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCol : Aleman5DLL.Collisions.Box
{
    public override void OnCollision(Aleman5DLL.Collisions.Box collision)
    {
        if (collision.GetTypeElem() == Aleman5DLL.Collisions.Elements.Enemy)
            SceneManager.LoadScene(0);
    }
}