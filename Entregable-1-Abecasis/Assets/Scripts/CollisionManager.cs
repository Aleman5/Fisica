using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    static CollisionManager instance;

    public enum Elements
    {
        TANK_1 = 0,
        BULLET_1,
        TANK_2,
        BULLET_2,
        COUNT
    }

    List<List<Transform>> transforms;
    //List<List<bool>> relations;
    bool[,] relations;

    void Awake()
    {
        int count = (int)Elements.COUNT;

        for (int i = 0; i < count; i++)
        {
            transforms.Add(new List<Transform>());

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
        for (int l1 = 0; l1 < transforms.Count; l1++)
            for (int l2 = l1; l2 < transforms[l1].Count; l2++)
                if (relations[l1, l2])
                    RealCollisionDetecter(l1, l2);
    }

    void RealCollisionDetecter(int index1, int index2)
    {
        if (transforms[index1].Count == 0 || transforms[index2].Count == 0)
            return;

        for (int l1 = 0; l1 < transforms[index1].Count; l1++)
        {
            for (int l2 = 0; l2 < transforms[index2].Count; l2++)
            {

            }
        }
    }

    public void AddToDetector(Transform tObject, Elements element)
    {
        transforms[(int)element].Add(tObject);
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
