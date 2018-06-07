using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{

    public Animator animator;

    public GameObject painelInventario;
    public GameObject painelWork;
    public GameObject btPlay;
    public GameObject player;
    public GameObject listaBtMetodos;
    public GameObject[] slots;

    public string[] metodos;
    //public string[] comandosFinal;
    public IList<string> comandosFinalList;
    public float pos, speed;
    public bool executaPlay = false;
    public bool delayLiberado = false;
    private EstadosPlayer estadoAtual;
    public int movimentos, totalMovimentos;
    public float countdown = 3.0f;
    public float forcaPuloX = 35;
    public float forcaPuloY = 200f;


    public int moedasFase;

    void Start()
    {
        estadoAtual = EstadosPlayer.Parado;
        moedasFase = 0;
        //slots = painelInventario.gameObject.GetComponentsInChildren<GameObject>();
        //Debug.Log("Teste: " + slots[0].name);
        /*animator.SetBool("playerIsGrounded", true);
        animator.SetBool("playerIsDead", false);
        animator.SetFloat("playerSpeed", Math.Abs(player.gameObject.GetComponent<Transform>().position.x / speed));*/
    }

    // Update is called once per frame
    void Update()
    {
        metodos = painelInventario.GetComponent<Inventory>().ListarMovimentos();
        if (metodos.Length > 1 && executaPlay == false)
        {
            btPlay.GetComponent<Button>().interactable = true;
        }
        else
        {
            btPlay.GetComponent<Button>().interactable = false;
        }

        if (estadoAtual != EstadosPlayer.Parado)
        {
            countdown -= Time.deltaTime;
        }

        if (executaPlay)
        {
            if (movimentos <= totalMovimentos + 1)
            {
                switch (estadoAtual)
                {
                    case EstadosPlayer.Aguardando:
                        {
                            Debug.Log("Aguardando comando");
                            VerificaProximoMovimento();
                            break;
                        }
                    case EstadosPlayer.Movendo:
                        {
                            Debug.Log("Movimentou o personagem");
                            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(player.GetComponent<Transform>().transform.position.x + pos, player.GetComponent<Transform>().transform.position.y));
                            Debug.Log(player.GetComponent<Transform>().position.x);

                            VerificaProximoMovimento();
                            break;
                        }
                    case EstadosPlayer.Pulando:
                        {
                            Debug.Log("Pulou o personagem");
                            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(forcaPuloX, forcaPuloY));
                            VerificaProximoMovimento();
                            break;
                        }
                    case EstadosPlayer.Delay:
                        {
                            if (countdown <= 0.0f)
                            {
                                delayLiberado = true;
                                Debug.Log("Deley personagem");
                            }

                            if (delayLiberado)
                            {
                                Debug.Log("Fim do deley personagem");
                                delayLiberado = false;
                                VerificaProximoMovimento();
                            }

                            break;
                        }
                    case EstadosPlayer.Parado:
                        {
                            Debug.Log("Fim da Rodada");
                            btPlay.GetComponent<Button>().interactable = true;
                            executaPlay = false;
                            break;
                        }

                    default:
                        {
                            Debug.Log("Opção inválida");
                            break;
                        }
                }
            }

        }


    }

    private void VerificaProximoMovimento()
    {
        if (comandosFinalList[movimentos].ToString() == "Mover")
        {
            Debug.Log("Mover");
            estadoAtual = EstadosPlayer.Movendo;
        }
        else if (comandosFinalList[movimentos].ToString() == "Pular")
        {
            Debug.Log("Pular");
            estadoAtual = EstadosPlayer.Pulando;
        }
        else if (comandosFinalList[movimentos].ToString() == "Delay")
        {
            countdown = 3.0f;
            estadoAtual = EstadosPlayer.Delay;
            Debug.Log("Delay");
        }
        else if (comandosFinalList[movimentos].ToString() == "Fim")
        {
            estadoAtual = EstadosPlayer.Parado;
            Debug.Log("Parado");
        }
        else
        {
            Debug.Log("Opção Inválida: " + comandosFinalList[movimentos].ToString());

        }
        movimentos++;



        /*if (comandosFinal[movimentos] == "Mover")
        {
            Debug.Log("Mover");
            estadoAtual = EstadosPlayer.Movendo;
        }
        else if (comandosFinal[movimentos] == "Pular")
        {
            Debug.Log("Pular");
            estadoAtual = EstadosPlayer.Pulando;
        }
        else if (comandosFinal[movimentos] == "Delay")
        {
            countdown = 3.0f;
            estadoAtual = EstadosPlayer.Delay;
            Debug.Log("Delay");
        }
        else if (comandosFinal[movimentos] == "Fim")
        {
            estadoAtual = EstadosPlayer.Parado;
            Debug.Log("Parado");
        }
        else
        {
            Debug.Log("Opção Inválida: " + comandosFinal[movimentos]);

        }
        movimentos++;*/
    }

    public void AcaoBotaoMenuMetodos(GameObject go)
    {
        if (go.activeSelf == false)
        {
            go.gameObject.SetActive(true);
        }
        else
        {
            go.gameObject.SetActive(false);
        }
    }

    public void AcaoBotaoOpenTips(GameObject go)
    {
        if (go.activeSelf == false)
        {
            go.gameObject.SetActive(true);
        }
        else
        {
            go.gameObject.SetActive(false);
        }
    }

    public void AcaoBotaoPlay()
    {
        btPlay.GetComponent<Button>().interactable = false;
        comandosFinalList = new List<string>();
        for (int i = 0; i < metodos.Length - 1; i++)
        {
            if (metodos[i].Trim().CompareTo("Repetir2x") == 0)
            {
                int primeiroI = i + 1;
                IList<string> listaFor = new List<string>();

                while (metodos[primeiroI].Trim().CompareTo("FimFor2x") != 0)
                {
                    listaFor.Add(metodos[primeiroI].Trim());
                    primeiroI++;
                }

                for (int j = 0; j < 2; j++)
                {
                    foreach (string m in listaFor)
                    {
                        Debug.Log("comandosFinalList.Count:" + comandosFinalList.Count);
                        comandosFinalList.Add(m);
                        comandosFinalList.Add("Delay");
                    }
                }
                i = primeiroI;
            }
            if (metodos[i].Trim().CompareTo("Repetir4x") == 0)
            {
                int primeiroI = i + 1;
                IList<string> listaFor = new List<string>();

                while (metodos[primeiroI].Trim().CompareTo("FimFor4x") != 0)
                {
                    listaFor.Add(metodos[primeiroI].Trim());
                    primeiroI++;
                }

                for (int j = 0; j < 4; j++)
                {
                    foreach (string m in listaFor)
                    {
                        Debug.Log("comandosFinalList.Count:" + comandosFinalList.Count);
                        comandosFinalList.Add(m);
                        comandosFinalList.Add("Delay");
                    }
                }
                i = primeiroI;
            }

            else
            {
                comandosFinalList.Add(metodos[i].Trim());
                comandosFinalList.Add("Delay");
            }
        }
        comandosFinalList.Add("Fim");
        movimentos = 0;
        totalMovimentos = comandosFinalList.Count;
        estadoAtual = EstadosPlayer.Aguardando;
        executaPlay = true;

        Debug.Log("Inicio");
    }

}

public enum EstadosPlayer
{
    Movendo,
    Pulando,
    Aguardando,
    Delay,
    Parado
}
