using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    static CollisionManager instance;

    public enum Elements
    {
        TANK_0 = 0,
        BULLET_0,
        TANK_1,
        BULLET_1,
        COUNT
    }

    List<List<IColBox>> transforms;
    
    bool[,] relations;

    void Awake()
    {
        int count = (int)Elements.COUNT;

        transforms = new List<List<IColBox>>();

        for (int i = 0; i < count; i++)
        {
            transforms.Add(new List<IColBox>());

            relations = new bool[count, count];

            for (int c = 0; c < count; c++)
                for (int v = 0; v < count; v++)
                    relations[c, v] = false;
        }
    }

    void Update()
    {
        CheckCollisions();
    }

    void SetRelation(int elem1, int elem2)
    {
        if (elem1 <= elem2)
            relations[elem1, elem2] = true;
        else
            relations[elem2, elem1] = true;
    }

    void CheckCollisions()
    {
        for (int tank = 0; tank < transforms.Count; tank += 2)
            for (int bullet = 1; bullet < transforms.Count; bullet += 2)
            {
                int b = tank + 1;

                if (b != bullet) // It means that this bullet's list is not from this tank
                {
                    //Debug.Log(tank + " " + bullet);
                    CollisionTankBullets(transforms[tank], transforms[bullet]);
                }
            }
    }

    void CollisionTankBullets(List<IColBox> tank, List<IColBox> bullets)
    {
        if (tank.Count == 0 || bullets.Count == 0)
            return;

        Vector2 hitBox1 = tank[0].GetBoxValues();

        for (int i = 0; i < bullets.Count; i++)
        {
            Vector3 diff = bullets[i].GetPosition() - tank[0].GetPosition();

            float diffX = Mathf.Abs(diff.x);
            float diffY = Mathf.Abs(diff.y);

            Vector2 hitBox2 = bullets[i].GetBoxValues();
            
            if (diffX < hitBox1.x + hitBox2.x && diffY < hitBox1.y + hitBox2.y)
            {
                tank[0].OnCollision();
                bullets[i].OnCollision();
                bullets.RemoveAt(i--);
            }
        }
    }

    public void AddToDetector(IColBox tObject)
    {
        transforms[(int)tObject.GetTypeElem()].Add(tObject);
    }

    static public CollisionManager Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType<CollisionManager>();
                if (!instance)
                {
                    GameObject go = new GameObject("Managers");
                    instance = go.AddComponent<CollisionManager>();
                }
            }
            return instance;
        }
    }
}
