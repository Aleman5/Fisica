using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsMovement : MonoBehaviour
{
    public enum TypeOfObject
    {
        Car = 0,
        Enviroment,
        Floor
    }

    [SerializeField] float speed;
    //[SerializeField] float extraSpeed;
    [SerializeField] float limit;
    [SerializeField] TypeOfObject type;
    
    float actualSpeed;

    Vector2 parent;

    void Awake()
    {
        parent = transform.parent.position;
        actualSpeed = speed;
    }

    void Update()
    {
        if (transform.position.y <= limit) LimitReached();

        float y = Aleman5DLL.Physics.NextPositionMRU(actualSpeed);
        transform.position += new Vector3(0.0f, y, 0.0f);
    }

    public void LimitReached()
    {
        GameManager.Instance.AddPoints((int)type);
        
        if (type == TypeOfObject.Floor)
            transform.position = new Vector2(parent.x, parent.y + 8.0f);
        else
            Destroy(gameObject);
    }

    public void SetSpeed(float speed)
    {
        actualSpeed = speed;
    }

    public int GetElemType()
    {
        return (int)type;
    }
}

/*float radio = 1.0f;
    float angle = 0.0f;

    private void Awake()
    {
        fireGameObjects = new List<Transform>();

        for (int i = 0; i < fires; i++)
            fireGameObjects.Add(Instantiate(fire, transform).transform);
    }

    void Update()
    {
        angle += speed * Time.deltaTime;
        if (angle >= 360.0f) angle = 0.0f;

        for (int i = 0; i < fires; i++)
        {
            Vector3 extraPos = Aleman5DLL.Physics.MCU(angle, radio * (i+1));
            fireGameObjects[i].position = transform.position + extraPos;
        }
    }*/