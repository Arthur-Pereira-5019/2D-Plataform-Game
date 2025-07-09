using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lanterncollider : MonoBehaviour
{
    public string tagPlayer;
    public GameObject gameObject;


    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.tag == tagPlayer)
        {
            GameObject foundObject = GameObject.Find("Manager");
            Destroy(gameObject);

            foundObject.GetComponent<GameManager>().points += 3;
            outro.GetComponent<Controle>().secondWeapon = true;
            foundObject.GetComponent<GameManager>().weapon = "Lanterna";
        }
    }

}
