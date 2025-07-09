using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controle : MonoBehaviour
{

    public int velocidade = 10;

    public float jumpTime = 10;

    public bool secondWeapon = false;
    public int forcaDoPulo = 1250;
    public Transform terra;
    public LayerMask chao;

    public float attackTime = 0.0f;

    public float attackTime2 = 0.0f;

    private float moveX;
    private bool direita = true;
    private bool noChao;
    private Animator animator;

    private GameObject manager;

    // Use this for initialization
    void Start()
    {
        manager = GameObject.Find("Manager");
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.GetComponent<GameManager>().lifes > 0 || manager.GetComponent<GameManager>().won == false)
        {
            moveJogador();
            }
        
    }

    private void LateUpdate()
    {
        viraJogador();
    }

    void moveJogador()
    {
        // CONTROLES
        moveX = Input.GetAxis("Horizontal");
        noChao = Physics2D.Linecast(transform.position, terra.position, chao);
        if (Input.GetButtonDown("Fire1") && animator.GetBool("Ataque") == false && animator.GetBool("Attack2") == false)
        {
            if (secondWeapon)
            {
                animator.SetBool("Idle", false);
                StartCoroutine(ataca2());
            }
            else
            {
                animator.SetBool("Idle", false);
                StartCoroutine(ataca());
            }
            
        }
        if (Input.GetButtonDown("Jump") && noChao)
        {
            {
                animator.SetBool("Idle", false);
                StartCoroutine(pula());
            }
        }

        // FÍSICA
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * velocidade,
                                                                      gameObject.GetComponent<Rigidbody2D>().velocity.y);

        Physics2D.IgnoreLayerCollision(this.gameObject.layer, LayerMask.NameToLayer("chao"),
                                       (gameObject.GetComponent<Rigidbody2D>().velocity.y > 0.0f));

        // ANIMAÇAO
        animator.SetBool("NoChao", noChao);

        if (moveX != 0)
        {
            animator.SetBool("Correndo", true);
            animator.SetBool("Idle", false);
        }
        else
        {
            animator.SetBool("Correndo", false);
            animator.SetBool("Idle", false);
        }
    }

    public IEnumerator ataca()
    {
        animator.SetBool("Ataque", true);
        yield return new WaitForSeconds(attackTime);
        animator.SetBool("Ataque", false);
        
    }

    public IEnumerator ataca2()
    {
        animator.SetBool("Attack2", true);
        yield return new WaitForSeconds(attackTime2);
        animator.SetBool("Attack2", false);
        manager.GetComponent<GameManager>().weapon = "Bengala";
        secondWeapon = false;
    }

    

    IEnumerator pula(){
        animator.SetTrigger("Pulando");
        yield return new WaitForSeconds(jumpTime);
        if (noChao == true && animator.GetBool("Correndo") == false)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * forcaDoPulo);
            animator.SetBool("Pulando", false);
        }
   
    }

    void viraJogador()
    {
        if (moveX > 0){
            direita = true;
        }
        else if(moveX < 0){
            direita = false;
        }
        Vector2 escala = transform.localScale;
        if((escala.x > 0 && !direita) || (escala.x < 0 && direita)){
            escala.x = escala.x * -1;
            transform.localScale = escala;
        }
    }

	// Código da plataforma movel
	void OnCollisionEnter2D(Collision2D outro)
	{
        if(outro.gameObject.tag=="PlataformaMovel"){
            this.transform.parent = outro.transform;
        }
	}

	private void OnCollisionExit2D(Collision2D outro)
	{
        if (outro.gameObject.tag == "PlataformaMovel")
        {
            this.transform.parent = null;
        }
	}
}
