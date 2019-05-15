using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    static UIManager instance;

    [SerializeField] Text ptsText;
    [SerializeField] Text levelText;

    void Start()
    {
        ptsText.text = "Points: " + GameManager.Instance.GetActualPoints();
        levelText.text = "Level: " + GameManager.Instance.GetActualLevel();
    }

    public void PointsUpdate()
    {
        ptsText.text = "Points: " + GameManager.Instance.GetActualPoints();
    }

    public void NewLevelReached()
    {
        levelText.text = "Level: " + GameManager.Instance.GetActualLevel();
    }

    static public UIManager Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType<UIManager>();
                if (!instance)
                {
                    GameObject go = new GameObject("Managers");
                    instance = go.AddComponent<UIManager>();
                }
            }
            return instance;
        }
    }
}
