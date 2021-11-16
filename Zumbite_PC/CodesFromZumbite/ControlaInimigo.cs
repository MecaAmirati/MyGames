using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour, IMatavel
{

    public GameObject Jogador;
    private MovimentoPersonagem movimentaInimigo;
    private AnimacaoPersonagem animacaoInimigo;
    private Status statusInimigo;
    //public AudioClip SomDeMorte;
    private Vector3 posicaoAleatoria;
    private Vector3 direcao;
    private float contadorVagar;
    private float tempoEntrePosicoesAleatorias = 3;
    private ControlaInterface scriptControlaInterface;
    public GeradorZumbis meuGerador;
    public GameObject ParticulaSangueZumbi;

    private Rigidbody meuRigidbody;

    void Start()
    {
        Jogador = GameObject.FindWithTag("Jogador");
        animacaoInimigo = GetComponent<AnimacaoPersonagem>();
        movimentaInimigo = GetComponent<MovimentoPersonagem>();
        AleatorizarZumbi();
        statusInimigo = GetComponent<Status>();

        scriptControlaInterface = GameObject.FindObjectOfType(typeof(ControlaInterface)) as ControlaInterface;
    }

    void FixedUpdate()
    {
        float distancia = Vector3.Distance(transform.position, Jogador.transform.position);

        //direcao = Jogador.transform.position - transform.position;
        movimentaInimigo.Rotacionar(direcao);
        animacaoInimigo.Movimentar(direcao.sqrMagnitude);

        if (distancia > 20)
        {
            Vagar();
        }
        else if (distancia > 2.5)
        {
            direcao = Jogador.transform.position - transform.position;
            movimentaInimigo.Movimentar(direcao, statusInimigo.Velocidade);
            animacaoInimigo.Atacar(false);
        }
        else
        {
            direcao = Jogador.transform.position - transform.position;
            Vector3 position = Jogador.transform.position;
            direcao = position - transform.position;

            animacaoInimigo.Atacar(true);
        }
    }

    void Vagar()
    {
        contadorVagar -= Time.deltaTime;
        if (contadorVagar <= 0)
        {
            posicaoAleatoria = AleatorizarPosicao();
            contadorVagar += tempoEntrePosicoesAleatorias + Random.Range(-1f,2f);
        }

        bool ficouPertoOSuficiente = Vector3.Distance(transform.position, posicaoAleatoria) <= 0.05;
        if (ficouPertoOSuficiente == false)
        {
            direcao = posicaoAleatoria - transform.position;
            movimentaInimigo.Movimentar(direcao, statusInimigo.Velocidade);
        }
    }

    Vector3 AleatorizarPosicao()
    {
        Vector3 posicao = Random.insideUnitSphere * 10;
        posicao += transform.position;
        posicao.y = transform.position.y;

        return posicao;
    }

    public void AtacaJogador()
    {
        int dano = Random.Range(20, 30);
        Jogador.GetComponent<ControlaJogador>().TomarDano(dano);
    }

    public void AleatorizarZumbi()
    {
        int geraTipoZumbi = Random.Range(1, transform.childCount);
        transform.GetChild(geraTipoZumbi).gameObject.SetActive(true);
    }

    public void TomarDano(int dano)
    {
        statusInimigo.Vida -= dano;
        if (statusInimigo.Vida <= 0)
        {
            //VerificarGeracaoKitMedico(porcentagemGerarKitMedico);
            scriptControlaInterface.AtualizarQuantidadeDeZumbisMortos();
            meuGerador.DiminuirQuantidadeDeZumbisVivos();

             
            GetComponent<Collider>().enabled = false;
            //GetComponent<Rigidbody>().position = Vector3.zero;
            this.enabled = false;

            Morrer();

        }
    }

    public void ParticulaSangue(Vector3 posicao, Quaternion rotacao)
    {
        Instantiate(ParticulaSangueZumbi, posicao, rotacao);
    }

    public void Morrer()
    {
        
        animacaoInimigo.Morrer();
        
        Invoke("EsperarCair", 2);//this will happen after 2 seconds

        Destroy(gameObject, 5);
      //ControlaAudio.instancia.PlayOneShot(SomDeMorte);

    }
    public void EsperarCair()
    {
        movimentaInimigo.Morrer();
    }
}