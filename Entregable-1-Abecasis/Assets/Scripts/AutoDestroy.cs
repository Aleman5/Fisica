using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    float time;

    void Awake()
    {
        time = 3.5f;
    }

    void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0)
            Destroy(gameObject);
    }
}
