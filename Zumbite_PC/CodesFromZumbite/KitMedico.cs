using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitMedico : MonoBehaviour
{
    private int quantidadeDeCura = 30;
    private int tempoDeDestruicao = 10;

    private void Start()
    {
        Destroy(gameObject, tempoDeDestruicao);
    }
    private void OnTriggerEnter(Collider objetoDeColisao)
    {
        if(objetoDeColisao.tag == "Jogador")
        {
            objetoDeColisao.GetComponent<ControlaJogador>().CurarVida(quantidadeDeCura);
            Destroy(gameObject);
        }
    }

}
