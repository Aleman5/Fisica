using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public enum TypeOfObject
    {
        Car = 0,
        Enviroment,
        Floor
    }

    [Header("Objects")]
    [SerializeField] List<GameObject> objects;

    [Header("Timers")]
    [SerializeField] float timePerSpawn;
    [SerializeField] float deltaT;

    [Header("Car Speeds")]
    [SerializeField] float speed;
    [SerializeField] float extraSpeed;

    float timeLeft = 1.0f;

    void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            float x = Random.Range(-8.3f, 8.3f);

            ObjectsMovement oM = Instantiate(objects[Random.Range(0, objects.Count - 1)], 
                                             new Vector3(x, transform.position.y, 0.0f), 
                                             transform.rotation, 
                                             transform                                   ).GetComponent<ObjectsMovement>();

            if(oM.GetElemType() == (int)TypeOfObject.Car)
                oM.SetSpeed(speed - Random.Range(extraSpeed * 0.7f, extraSpeed * 1.2f));

            timeLeft = timePerSpawn + Random.Range(-deltaT, deltaT);
        }
    }

    public void NewLevelReached()
    {
        if (timePerSpawn >= 1.5f)
            timePerSpawn -= 0.15f;
    }

}
