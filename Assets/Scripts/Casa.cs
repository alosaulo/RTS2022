using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
        
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
        Relogio -= Time.deltaTime;

        if(carne > 500)
        {
            if(populacao > 15)
            {
                Criar("L");
            }
            else
            {
                Criar("C");
            }
            
            
        }
        
        if(madeira > 100)
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
}
