using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casa : MonoBehaviour
{
    public GameObject Floresta;
    public GameObject Animais;
    public GameObject Lazer;
    public int madeira;
    public int carne;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
