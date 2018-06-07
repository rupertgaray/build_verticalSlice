using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    
    public GameObject painelInventario;
    public GameObject btPlay;
    public GameObject player;
    public GameObject listaBtMetodos;
    

    public string[] metodos;
    public string[] comandosFinal;
    public float pos, speed;
    public bool executaPlay = false;
    public bool delayLiberado = false;
    private EstadosPlayer estadoAtual;
    public int movimentos, totalMovimentos;
    public float countdown = 3.0f;
    public float forcaPulo = 200f;


    public int moedasFase;

    void Start()
    {
        estadoAtual = EstadosPlayer.Parado;
        moedasFase = 0;
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

        if (comandosFinal[movimentos] == "Mover")
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
            Debug.Log("Opção Inválida");

        }
        movimentos++;
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
        Debug.Log(btPlay.GetComponent<Button>().IsInteractable());
        btPlay.GetComponent<Button>().interactable = false;
        Debug.Log(btPlay.GetComponent<Button>().IsInteractable());
        comandosFinal = new string[(metodos.Length) * 2];
        int count = 0;
        for (int i = 0; i < metodos.Length - 1; i++)
        {
            comandosFinal[count] = metodos[i].Trim();
            count++;
            comandosFinal[count] = "Delay";
            count++;
        }
        comandosFinal[count] = "Fim";
        movimentos = 0;
        totalMovimentos = count;
        estadoAtual = EstadosPlayer.Aguardando;
        executaPlay = true;
        Debug.Log("Inicio");
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            moedasFase += 10;
            //Debug.Log("Total de moedas: " + moedasFase);
            Debug.Log(moedasFase.ToString());
            countCoin.text = moedasFase.ToString();
            collision.gameObject.SetActive(false);
        }
    }*/
    
}

public enum EstadosPlayer
{
    Movendo,
    Pulando,
    Aguardando,
    Delay,
    Parado
}
