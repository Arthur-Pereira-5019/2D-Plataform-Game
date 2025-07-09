using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Saude : MonoBehaviour
{

    public bool morto;
    public int saude;
    private Animator animator;
    public float deathTime;

    public GameObject self;

    // Use this for initialization
    void Start()
    {
        morto = false;
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
    }

    public void dano(int x)
    {
        Debug.Log("Entrei dano");
        saude -= x;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    IEnumerator morreInimigo()
    {
        yield return new WaitForSeconds(deathTime);
        Destroy(self);
    }
}