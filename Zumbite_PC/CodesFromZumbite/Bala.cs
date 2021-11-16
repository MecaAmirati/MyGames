using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float Projetil = 30;
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.forward * Projetil * Time.deltaTime);
    }

    void OnTriggerEnter(Collider objetoColisao)
    {
        Quaternion rotacaoOpostaABala = Quaternion.LookRotation (-transform.forward);
        switch(objetoColisao.tag) 
        {
            case "Inimigo":
                ControlaInimigo inimigo = objetoColisao.GetComponent<ControlaInimigo>();
                inimigo.TomarDano(1);
                inimigo.ParticulaSangue(transform.position, rotacaoOpostaABala);
                break;

            case "ChefeDeFase":
                ControlaChefe chefe = objetoColisao.GetComponent<ControlaChefe>();
                chefe.TomarDano(1);
                chefe.ParticulaSangue(transform.position, rotacaoOpostaABala);
                break;
        }

        Destroy(gameObject);
    }
}
