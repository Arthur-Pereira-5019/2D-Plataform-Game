using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int lifes = 3;
    public int points = 0;

    public TextMeshProUGUI score;

    public string weapon = "Bengala";

    public bool won = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    
    
    {
        GameObject foundObject = GameObject.Find("Canvas");
        string arma;
        score.text = "Pontos: " + points + "\n Arma:" + weapon + "\n Vidas: " + lifes;
        if (lifes <= 0)
        {
            foundObject.transform.Find("losePanel").gameObject.SetActive(true);
        }
        else if (won == true)
        {
            foundObject.transform.Find("winPanel").gameObject.SetActive(true);
        }
    }
}
