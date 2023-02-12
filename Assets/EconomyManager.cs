using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EconomyManager : MonoBehaviour
{
    public int Score;
    public float Health;
    public float Boost;
    public UIManager UIManager;
    public Text ScoreText; 
    public Text BoostText; 
    public Text HealthText;
    string scoreKey = "Score";

    // Start is called before the first frame update
    void Start()
    {
        UIManager.CreateTextValue(scoreKey, "000", ScoreText);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UIManager.UpdateTextValue(scoreKey, Score.ToString("d3"));
    }
}
