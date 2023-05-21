using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform pontoAtaque;

    [SerializeField]
    private float raioAtaque;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    private void OnDrawGizmos()
    {
        if (this.pontoAtaque != null)
        {
            Gizmos.DrawWireSphere(this.pontoAtaque.position, this.raioAtaque);
        }
    }

   private void Attack()
{
    Collider2D colliderInimigo = Physics2D.OverlapCircle(this.pontoAtaque.position, this.raioAtaque);
    if (colliderInimigo != null)
    {
        Debug.Log("Collider Inimigo: " + colliderInimigo);
        Debug.Log("Collider Inimigo Nome: " + colliderInimigo.name);
        
        Inimigo inimigo = colliderInimigo.GetComponent<Inimigo>();
        if (inimigo != null)
        {
            inimigo.ReceberDano();
        }
    }
}

}
