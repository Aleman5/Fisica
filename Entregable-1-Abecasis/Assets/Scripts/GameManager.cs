using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    struct Tank
    {
        public Move moveScript;
        public Throw throwScript;
    }

    [SerializeField] List<Transform> tanks;

    List<Tank> tankScripts;

    /*private void Awake()
    {
        for (int i = 0; i < tanks.Count; i++)
        {
            tankScripts.Add(new Tank());
            tankScripts[i].moveScript = tanks[i].transform.gameObject.GetComponent<Move>();
        }

        foreach (Transform tank in tanks)
        {
            tankScripts.moveScript = tank.transform.gameObject.GetComponent<Move>();
        }
    }*/
}
