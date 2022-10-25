using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Casa : MonoBehaviour
{
    public GameObject Floresta;
    public GameObject Animais;
    public GameObject Lazer;
    public GameObject PrefabTrabalhador;
    public List<GameObject> Trabalhadores;
    public int madeira = 50;
    public int carne = 500;
    public int populacao;
    public int LimitePopulacao;
    private int qtdCasas = 1;
    public float Relogio = 300;
    private float tempoCarne = 0;
    private float tempoMadeira = 0;
    private int pessoaLazer = 0;
    //DadosDaCasa
    public Text Dadopopulacao;
    public Text Dadocarne;
    public Text Dadomadeira;
    public Text Dadovagabundo;
    public Text DadoTempo;

    private int TrabalhadoresCarne = 3;
    private int NecessitaVagabundo = 0;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 5;
        Criar("C");
        Criar("C");
        Criar("C");
        Criar("M");
        Criar("M");
    }

    // Update is called once per frame
    void Update()
    {
        LimitePopulacao = qtdCasas * 5;
        populacao = Trabalhadores.Count;
        TempoDoJogo();
        Visualizar();
        if(carne > 150)
        {
            if(populacao > 30)
            {
                Criar("L");
                
            }
            else
            {
                
                if(TrabalhadoresCarne > 4)
                {
                    Criar("M");
                    TrabalhadoresCarne = 0;
                }
                else
                {
                    Criar("C");
                    TrabalhadoresCarne++;
                }
                
            }
            
            
        }
        
        if(madeira > 90)
        {
            CriarCasa();
        }


    }

    public void ReceberMadeira(int mad)
    {
        //Recebendo a madeira do trabalhador;
        madeira = madeira + mad;
    }

    public void ReceberCarne(int car)
    {
        //Recebendo a madeira do trabalhador;
        carne = carne+ car;
    }

    void Criar(string Letra)
    {
        //Verifica Se pode Construir
        if(LimitePopulacao > populacao)
        {
            if(carne > 50)
            {
                //Perde carne para criar um novo trabalhador
                carne = carne - 50;
                GameObject meuTrabalhador = Instantiate(PrefabTrabalhador, transform.position, Quaternion.identity);
                meuTrabalhador.GetComponent<Trabalhador>().MinhaCasa = this.gameObject;
                if (Letra == "C")
                {
                    meuTrabalhador.GetComponent<Trabalhador>().DefinirTipo("Carne");
                }
                if (Letra == "M")
                {
                    meuTrabalhador.GetComponent<Trabalhador>().DefinirTipo("Madeira");
                }
                if (Letra == "L")
                {
                    meuTrabalhador.GetComponent<Trabalhador>().DefinirTipo("Lazer");
                    
                }
                Trabalhadores.Add(meuTrabalhador);
            }
        }

    }

    void CriarCasa()
    {
        if(madeira > 50)
        {
            qtdCasas++;
            madeira = madeira - 50;
        }
    }

    void TempoDoJogo()
    {
        Relogio -= Time.deltaTime;
        Consumo();
        if (Relogio <= 0)
        {
            Debug.Log("Acabou o Tempo");
            Time.timeScale = 0;
        }
    }

    void Consumo()
    {
        tempoCarne += Time.deltaTime;
        tempoMadeira += Time.deltaTime;

        if(tempoCarne > 5)
        {
            tempoCarne = 0;
            carne = carne - populacao;
            if(carne < 0)
            {
                Debug.Log("Morreu de Fome");
                Time.timeScale = 0;
            }
        }
        if(tempoMadeira > 10)
        {
            tempoMadeira = 0;
            madeira = madeira - populacao;
            if(madeira < 0)
            {
                Debug.Log("Morreu de Frio");
                Time.timeScale = 0;
            }
        }
    }

    public void EstouCurtindo()
    {
        pessoaLazer++;
    }

    void Visualizar()
    {
        Dadopopulacao.text = "População: "+populacao.ToString()+" /"+LimitePopulacao.ToString();
        Dadocarne.text = "Carne: "+carne.ToString();
        Dadomadeira.text = "Madeira: "+madeira.ToString();
        Dadovagabundo.text = "Lazer: "+ pessoaLazer.ToString();
        DadoTempo.text = "Para Acabar: " + Relogio.ToString()+" segundos";
    }
}
