using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    [System.Serializable]
    public struct Tank
    {
        public string tankName;
        public Transform tankTransform;
        public Move moveScript;
        public Throw throwScript;
        public WeaponRotation weaRotScript;
    }

    [SerializeField] List<Tank> tanks;
    [SerializeField] float timePerTurn;

    int turnOf;
    float timeLeft;

    void Awake()
    {
        for (int i = 1; i < tanks.Count; i++)
        {
            tanks[i].moveScript.enabled = false;
            tanks[i].throwScript.enabled = false;
            tanks[i].weaRotScript.enabled = false;
        }

        turnOf = 0; // Tank 0 always starts
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            tanks[turnOf].moveScript.enabled = false;
            tanks[turnOf].throwScript.enabled = false;
            tanks[turnOf].weaRotScript.enabled = false;

            if (++turnOf == tanks.Count) turnOf = 0;

            tanks[turnOf].moveScript.enabled = true;
            tanks[turnOf].throwScript.enabled = true;
            tanks[turnOf].weaRotScript.enabled = true;

            timeLeft = timePerTurn;
        }
    }

    public float GetTimeLeft() { return timeLeft; }

    public float GetTimePerTurn() { return timePerTurn; }

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
