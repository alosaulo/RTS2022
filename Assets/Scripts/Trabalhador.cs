using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Trabalhador : MonoBehaviour
{
    private NavMeshAgent Agente;
    public GameObject MinhaCasa;
    private GameObject Floresta;
    private GameObject Animais;
    private GameObject Lazer;
    public int madeira;
    public int carne;
    public bool colhendo = true;
    public string tipo = "";
    private float temporizador;

    void Start()
    {

        Animais = MinhaCasa.GetComponent<Casa>().Animais;
        Floresta = MinhaCasa.GetComponent<Casa>().Floresta;
        Lazer = MinhaCasa.GetComponent<Casa>().Lazer;
        Agente = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Navegacao();
    }

    void Navegacao()
    {
        
        if(tipo == "Carne")
        {
            TrabalharCarne();
        }
        if(tipo == "Madeira")
        {
            TrabalharMadeira();
        }
        if (tipo == "Lazer")
        {
            CurtirAVida();
        }




    }

    public void TrabalharMadeira()
    {
        //Ir buscar madeira
        if (colhendo)
        {

            //Chegou na madeira
            if (Vector3.Distance(transform.position, Floresta.transform.position) < 3)
            {
                Agente.speed = 0;
                temporizador += Time.deltaTime;
                if (temporizador > 0.1f)
                {
                    madeira++;
                    temporizador = 0;
                }
                if (madeira >= 10)
                {
                    colhendo = false;
                }
            }
            else
            {
                //Esta indo em diração a madeira
                Agente.speed = 10;
                Agente.SetDestination(Floresta.transform.position);
            }

        }
        //Voltar para casa
        if (colhendo == false)
        {
            //peto da casa
            if (Vector3.Distance(transform.position, MinhaCasa.transform.position) < 3)
            {
                MinhaCasa.GetComponent<Casa>().ReceberMadeira(madeira);
                madeira = 0;
                colhendo = true;
            }
            else
            {
                //distante da casa
                Agente.speed = 10;
                Agente.SetDestination(MinhaCasa.transform.position);
            }
        }
    }

    public void TrabalharCarne()
    {
        //Ir buscar madeira
        if (colhendo)
        {

            //Chegou na madeira
            if (Vector3.Distance(transform.position, Animais.transform.position) < 3)
            {
                Agente.speed = 0;
                temporizador += Time.deltaTime;
                if (temporizador > 0.1f)
                {
                    carne++;
                    temporizador = 0;
                }
                
                if (carne >= 10)
                {
                    colhendo = false;
                }
            }
            else
            {
                //Esta indo em diração a madeira
                Agente.speed = 10;
                Agente.SetDestination(Animais.transform.position);
            }

        }
        //Voltar para casa
        if (colhendo == false)
        {
            //peto da casa
            if (Vector3.Distance(transform.position, MinhaCasa.transform.position) < 3)
            {
                MinhaCasa.GetComponent<Casa>().ReceberCarne(carne);
                carne = 0;
                colhendo = true;
            }
            else
            {
                //distante da casa
                Agente.speed = 10;
                Agente.SetDestination(MinhaCasa.transform.position);
            }
        }
    }

    void CurtirAVida()
    {
        
        if (Vector3.Distance(transform.position, Lazer.transform.position) < 3)
        {
            Agente.speed = 0;
            temporizador += Time.deltaTime;
            if (temporizador > 1f)
            {
                MinhaCasa.GetComponent<Casa>().EstouCurtindo();
                temporizador = 0;
            }

        }
        else
        {
            Agente.speed = 10;
            Agente.SetDestination(Lazer.transform.position);
        }
    }

    public void DefinirTipo(string meuTipo)
    {
        tipo = meuTipo;
    }


   
}
