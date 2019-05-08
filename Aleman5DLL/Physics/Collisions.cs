using System.Collections.Generic;
using UnityEngine;

namespace Aleman5DLL
{
    public static class Collisions
    {
        public enum Elements
        {
            Default = 0,
            Player,
            Enemy,
            Enviroment,
            Count
        }

        public class Box : MonoBehaviour
        {
            Vector2 hitBoxRadius;
            Elements type = Elements.Default;

            void Start()
            {
                CollisionManager.Instance.AddToDetector(this);
            }

            public virtual void OnCollision(Box collision)
            {

            }

            public void SetData(Vector2 hitBox, Elements type)
            {
                hitBoxRadius = hitBox;
                this.type = type;
            }

            public Vector3 GetPosition() { return transform.position; }

            public Vector2 GetBoxValues() { return hitBoxRadius; }

            public Elements GetTypeElem() { return type; }
        }
    

        public class CollisionManager : MonoBehaviour
        {
            static CollisionManager instance;

            List<List<Box>> boxes;

            bool[,] relations;

            void Awake()
            {
                int count = (int)Elements.Count;

                // Boxes
                boxes = new List<List<Box>>();

                for (int i = 0; i < count; i++)
                    boxes.Add(new List<Box>());

                // Relations
                relations = new bool[count, count];

                for (int c = 0; c < count; c++)
                    for (int v = 0; v < count; v++)
                        relations[c, v] = false;
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
                int count = (int)Elements.Count;

                for (int i = 0; i < count; i++)
                    for (int j = i; j < count; j++)
                        if (relations[i,j])
                            MakeTheRealDetection(boxes[i], boxes[j]);
            }

            void MakeTheRealDetection(List<Box> l1, List<Box> l2)
            {
                if (l1.Count == 0 || l2.Count == 0)
                    return;

                List<Box> boxesCollided = new List<Box>();

                Vector2 hitBox1 = l1[0].GetBoxValues();

                for (int i = 0; i < l1.Count; i++)
                {
                    for (int j = 0; j < l2.Count; j++)
                    {
                        Vector3 diff = l2[i].GetPosition() - l1[0].GetPosition();

                        float diffX = Mathf.Abs(diff.x);
                        float diffY = Mathf.Abs(diff.y);

                        Vector2 hitBox2 = l2[i].GetBoxValues();

                        if (diffX < hitBox1.x + hitBox2.x && diffY < hitBox1.y + hitBox2.y)
                        {
                            l1[i].OnCollision(l2[j]);
                            l2[j].OnCollision(l1[i]);

                            if (!l1[i]) { l1.RemoveAt(i); i--; };
                            if (!l2[j]) { l2.RemoveAt(j); j--; };
                        }
                    }
                }
            }

            public void AddToDetector(Box tObject)
            {
                boxes[(int)tObject.GetTypeElem()].Add(tObject);
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
    }
}