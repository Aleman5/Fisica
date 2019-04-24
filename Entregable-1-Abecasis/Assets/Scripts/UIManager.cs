using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("TankTurn")]
    [SerializeField] Text tank;

    [Header("Time")]
    [SerializeField] Text timeLeftTxt;
    [SerializeField] Color colorA;
    [SerializeField] Color colorB;

    [Header("FillBar")]
    [SerializeField] Image fillBar;
    [SerializeField] List<Throw> throwScript;

    float timePerTurn;

    void Start()
    {
        timePerTurn = GameManager.Instance.GetTimePerTurn();
    }

    void Update()
    {
        // Time
        float t = GameManager.Instance.GetTimeLeft();
        timeLeftTxt.color = Color.Lerp(colorA, colorB, t / timePerTurn);
        timeLeftTxt.text = "Next turn: " + t;

        // Fill bar
        int turnOf = GameManager.Instance.GetTurnOf();
        if (throwScript[turnOf].TankState == Throw.TankStates.Charging)
            fillBar.fillAmount = throwScript[turnOf].GetActualCharge();

        // Tank turn
        tank.text = "Tank " + turnOf;
    }
}
