using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{

    public int lifes = 3;
    public int points = 0;

    public TMP_Text score;
    public TMP_Text finalScore;

    public string weapon = "Bengala";

    public int health;

    public bool won = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    
    
    {
        GameObject foundObject = GameObject.Find("Canvas");
        score.text = "Vida: " + health + "\n Pontos: " + points + "\n Arma: " + weapon + "\n Vidas: " + lifes;
        if (lifes <= 0)
        {
            foundObject.transform.Find("losePanel").gameObject.SetActive(true);
        }
        else if (won == true)
        {
            foundObject.transform.Find("winPanel").gameObject.SetActive(true);
            finalScore.text = "Pontuação Final: " + points;
        }
    }
}
