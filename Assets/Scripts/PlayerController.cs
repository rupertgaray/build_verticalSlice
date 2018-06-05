using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class PlayerController : MonoBehaviour{


    public GameObject painelInventario;
    public GameObject btPlay;
    public GameObject Player;
    public GameObject ListaBtMetodos;
    public string[] metodos;
    public string[] comandosFinal;
    
    void Start () {
        
    }

    // Update is called once per frame
    void Update()
    {
        metodos = painelInventario.GetComponent<Inventory>().ListarMovimentos();
        if (metodos.Length > 1)
        {
            btPlay.SetActive(true);
        }
        else
        {
            btPlay.SetActive(false);
        }
    }


    public void AcaoBotaoMenuMetodos(GameObject go)
    {
        //Debug.Log(go.activeSelf);

        if (go.activeSelf == false){
            go.gameObject.SetActive(true);
        }
        else
        {
            go.gameObject.SetActive(false);
        }

        //Debug.Log(go.activeSelf);

    }

    public void AcaoBotaoPlay()
    {
        ListaBtMetodos.SetActive(false);
        comandosFinal = new string[metodos.Length - 1];
        for (int i = 0; i < metodos.Length-1; i++)
        {
            comandosFinal[i] = metodos[i];
        }
        ExecutaJogada(comandosFinal);
    }

    private void ExecutaJogada(string[] comandosFinal)
    {
        
    }
}


