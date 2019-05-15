using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    public enum TypeOfObject
    {
        Car = 0,
        Enviroment,
        Floor
    }

    [SerializeField] int carPoints;
    [SerializeField] int EnviromentPoints;
    [SerializeField] int FloorPoints;

    int points = 0;
    int level = 1;

    void Awake()
    {
        Aleman5DLL.Collisions.CollisionManager colMng = Aleman5DLL.Collisions.CollisionManager.Instance;

        colMng.SetRelation((int)Aleman5DLL.Collisions.Elements.Player, (int)Aleman5DLL.Collisions.Elements.Enemy);
        colMng.SetRelation((int)Aleman5DLL.Collisions.Elements.Player, (int)Aleman5DLL.Collisions.Elements.Enviroment);
        colMng.SetRelation((int)Aleman5DLL.Collisions.Elements.Enemy, (int)Aleman5DLL.Collisions.Elements.Enviroment);
    }

    public void AddPoints(int type)
    {
        TypeOfObject realType = (TypeOfObject)type;
        
        switch(realType)
        {
            case TypeOfObject.Car:
                points += carPoints * level;
                UIManager.Instance.PointsUpdate();
            break;
            case TypeOfObject.Enviroment:
                points += EnviromentPoints * level;
                UIManager.Instance.PointsUpdate();
            break;
            case TypeOfObject.Floor:
                points += FloorPoints * level;
                UIManager.Instance.PointsUpdate();
                level++;
                UIManager.Instance.NewLevelReached();
            break;
        }
    }

    public int GetActualPoints() { return points; }

    public int GetActualLevel() { return level; }

    static public GameManager Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType<GameManager>();
                if (!instance)
                {
                    GameObject go = new GameObject("Managers");
                    instance = go.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }
}
