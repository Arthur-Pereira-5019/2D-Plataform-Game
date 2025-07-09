using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winCollider : MonoBehaviour
{
     public string tagPlayer;

    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.tag == tagPlayer)
        {
            GameObject foundObject = GameObject.Find("Manager");
            foundObject.GetComponent<GameManager>().points += 10 * foundObject.GetComponent<GameManager>().lifes;
            foundObject.GetComponent<GameManager>().won = true;
        }
    }
}
