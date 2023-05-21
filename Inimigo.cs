using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    float distanciaMinima = 0.8f;
    float velocidadeMovimento = 10;
    [SerializeField]
    public Transform alvo;

    [SerializeField]
    public float raioVisao;

    public void Update()
    {
        Mover();
    }

    public void Mover()
    {
        Vector2 posicaoAlvo = this.alvo.position;
        Vector2 posicaoAtual = this.transform.position;

        float distancia = Vector2.Distance(posicaoAtual, posicaoAlvo);
        if (distancia >= distanciaMinima)
        {
            Vector2 direcao = posicaoAlvo - posicaoAtual;
            direcao = direcao.normalized;

            this.GetComponent<Rigidbody2D>().velocity = (velocidadeMovimento * direcao);

            if (this.GetComponent<Rigidbody2D>().velocity.x > 0) 
            {
                this.GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (this.GetComponent<Rigidbody2D>().velocity.x < 0)
            {
                this.GetComponent<SpriteRenderer>().flipX = true;
            }
            this.GetComponent<Animator>().SetBool("movendo", true);
        
        }
        else
        {
            PararMovimentacao();
        }
    
    }


public void PararMovimentacao()
{
    this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    this.GetComponent<Animator>().SetBool("movendo", false);

}

public void ReceberDano()
{
    
}
}