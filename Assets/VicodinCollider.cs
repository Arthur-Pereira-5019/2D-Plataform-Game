using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VicodinCollider : MonoBehaviour
{
    public string tagPlayer;
    public int cura;

    public float drinkTime = 0.0f;

    public GameObject gameObject;


    private void OnTriggerEnter2D(Collider2D outro)
    {
        Debug.Log("A");
        if (outro.tag == tagPlayer)
        {
            StartCoroutine(tomar(outro));
        }
    }

    IEnumerator tomar(Collider2D outro)
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
        outro.gameObject.GetComponent<Animator>().SetBool("Tomando", true);
        outro.gameObject.GetComponent<Saude>().dano(-cura);
        yield return new WaitForSeconds(drinkTime);
        outro.gameObject.GetComponent<Animator>().SetBool("Tomando", false);
        Destroy(gameObject);
        Debug.Log("C");
    }
}
