using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Saude : MonoBehaviour
{

    public bool morto;
    public int saude;

    private int constHealth;
    private Animator animator;
    public float deathTime;

    public GameObject self;
    public GameObject foundObject;

    // Use this for initialization
    void Start()
    {
        morto = false;
        animator = gameObject.GetComponent<Animator>();
        constHealth = saude;
        foundObject = GameObject.Find("Manager");
        foundObject.GetComponent<GameManager>().health = saude;


    }

    void Update()
    {
    }

    public void dano(int x)
    {
        Debug.Log("Entrei dano");
        saude -= x;
        if (gameObject.tag == "Player")
        {
            foundObject.GetComponent<GameManager>().health = saude;
        }
        if (saude <= 0)
        {
            morto = true;
            animator.SetTrigger("Morte");
            if (gameObject.tag == "Player")
            {  // Só reicicia a fase se quem morreu foi o jogador.
                StartCoroutine(morre());
                

            }
            else
            {
                StartCoroutine(morreInimigo());
            }
        }
    }

    public void danoMax()
    {
        saude = 0;
        morto = true;
        animator.SetTrigger("Morte");
        if (gameObject.tag == "Player")
        {  // Só reicicia a fase se quem morreu foi o jogador.
            StartCoroutine(morre());
        }
    }

    IEnumerator morre()
    {
        yield return new WaitForSeconds(deathTime);
        animator.SetBool("Morte", false);
        foundObject.GetComponent<GameManager>().lifes -= 1;
        self.transform.position = GameObject.Find("SpawnPoint").GetComponent<Transform>().position;
        saude = constHealth;
            foundObject.GetComponent<GameManager>().health = saude;

        animator.SetBool("Idle", true);
    }
    IEnumerator morreInimigo()
    {
        foundObject.GetComponent<GameManager>().points += 5;
        yield return new WaitForSeconds(deathTime);
        Destroy(self);
    }
}