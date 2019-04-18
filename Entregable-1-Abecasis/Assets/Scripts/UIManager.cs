using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text timeLeftTxt;
    [SerializeField] Color colorA;
    [SerializeField] Color colorB;

    float timePerTurn;

    void Start()
    {
        timePerTurn = GameManager.Instance.GetTimePerTurn();
    }

    void Update()
    {
        float t = GameManager.Instance.GetTimeLeft();

        timeLeftTxt.color = Color.Lerp(colorA, colorB, t / timePerTurn);
        timeLeftTxt.text = "Time for next turn: " + t;
    }
}
