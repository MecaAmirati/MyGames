using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuJogador : MonoBehaviour
{
    private AnimacaoPersonagem animacaoJogador;
    public void Start()
    {
        int geraTipoJogador = Random.Range(1, 22);
        
        transform.GetChild(geraTipoJogador).gameObject.SetActive(true);
        animacaoJogador = GetComponent<AnimacaoPersonagem>();

    }
}
