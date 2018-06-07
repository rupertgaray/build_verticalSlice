using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{

    //[SerializeField] Transform slots;
    public Transform slots;

    public Animator animator;

    
    public GameObject painelInventario;
    public GameObject painelWork;
    public GameObject btPlay;
    public GameObject player;
    public GameObject listaBtMetodos;
    //public GameObject[] slots;

    public string[] metodos;
    public IList<string> comandosFinalList;
    public float pos, speed;
    public bool executaPlay = false;
    public bool delayLiberado = false;
    private EstadosPlayer estadoAtual;
    public int movimentos, totalMovimentos;
    public float countdown = 3.0f;
    public float forcaPuloX = 35;
    public float forcaPuloY = 200f;

    
    public IList<int> pintarSlots = new List<int>(); 

    public Slot[] slotsWork;
    public int jogadaCount = 0;

    void Start()
    {
        estadoAtual = EstadosPlayer.Parado;
    }

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
                            animator.SetBool("playerParado", false);
                            animator.SetBool("playerCaminhando", true);
                            Debug.Log("Movimentou o personagem");
                            
                            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(player.GetComponent<Transform>().transform.position.x + pos, player.GetComponent<Transform>().transform.position.y));
                            Debug.Log(player.GetComponent<Transform>().position.x);

                            VerificaProximoMovimento();
                            break;
                        }
                    case EstadosPlayer.Pulando:
                        {
                            animator.SetBool("playerParado", false);
                            animator.SetBool("playerPulando", true);
                            Debug.Log("Pulou o personagem");
                            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(forcaPuloX, forcaPuloY));
                            VerificaProximoMovimento();
                            break;
                        }
                    case EstadosPlayer.Delay:
                        {
                            animator.SetBool("playerParado", true);
                            animator.SetBool("playerCaminhando", false);
                            animator.SetBool("playerPulando", false);

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
            PintarSlot(jogadaCount);
            jogadaCount++;
            countdown = 3.0f;
            estadoAtual = EstadosPlayer.Delay;
            Debug.Log("Delay");
        }
        else if (comandosFinalList[movimentos].ToString() == "Fim")
        {
            estadoAtual = EstadosPlayer.Parado;
            Debug.Log("Parado");
        }
        else if (comandosFinalList[movimentos].ToString() == "Repetir2x")
        {
            estadoAtual = EstadosPlayer.Aguardando;
            Debug.Log("Parado");
        }
        else if (comandosFinalList[movimentos].ToString() == "FimFor2x")
        {
            estadoAtual = EstadosPlayer.Aguardando;
            Debug.Log("Parado");
        }
        else if (comandosFinalList[movimentos].ToString() == "Repetir4x")
        {
            estadoAtual = EstadosPlayer.Aguardando;
            Debug.Log("Parado");
        }
        else if (comandosFinalList[movimentos].ToString() == "FimFor4x")
        {
            estadoAtual = EstadosPlayer.Aguardando;
            Debug.Log("Parado");
        }
        else
        {
            Debug.Log("Opção Inválida: " + comandosFinalList[movimentos].ToString());

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
        
       btPlay.GetComponent<Button>().interactable = false;
        comandosFinalList = new List<string>();
        for (int i = 0; i < metodos.Length - 1; i++)
        {
            if (metodos[i].Trim().CompareTo("Repetir2x") == 0)
            {
                
                int primeiroI = i + 1;
                IList<string> listaFor = new List<string>();
                listaFor.Add(metodos[i].Trim());
                while (metodos[primeiroI].Trim().CompareTo("FimFor2x") != 0)
                {
                    listaFor.Add(metodos[primeiroI].Trim());
                    primeiroI++;
                }

                for (int j = 0; j < 2; j++)
                {
                    foreach (string m in listaFor)
                    {
                        comandosFinalList.Add(m);
                        comandosFinalList.Add("Delay");
                    }

                    if (j == 0)
                    {
                        comandosFinalList.Add("FimFor2x");
                    }
                }
                i = primeiroI;
            }
            if (metodos[i].Trim().CompareTo("Repetir4x") == 0)
            {
                int primeiroI = i + 1;
                IList<string> listaFor = new List<string>();
                listaFor.Add(metodos[i].Trim());
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
            //if (metodos[i].Trim().CompareTo("FimFor2x") == 0 || (metodos[i].Trim().CompareTo("FimFor4x") == 0))
            //{
               
            //}
            else
            {
                comandosFinalList.Add(metodos[i].Trim());
                comandosFinalList.Add("Delay");
                pintarSlots.Add(i);
            }
        }
        comandosFinalList.Add("Fim");
        movimentos = 0;
        totalMovimentos = comandosFinalList.Count;
        estadoAtual = EstadosPlayer.Aguardando;
        executaPlay = true;

        
        slotsWork = painelWork.GetComponentsInChildren<Slot>();

        foreach(string a in comandosFinalList)
        {
            Debug.Log(a);
        }


        Debug.Log("Inicio");
    }

    private void PintarSlot(int i)
    {
        Debug.Log(i);
        Slot st = slotsWork[i];
        Debug.Log("st.name" + st.name);
        if (st.item != null)
        {
            Debug.Log("st.item: " + st.item.name);
            if (st.item.name.CompareTo("FimFor2x") == 0) {
                Debug.LogWarning("Entrou");
                st.item.GetComponent<Image>().color = new Color(st.item.GetComponent<Image>().color.r, st.item.GetComponent<Image>().color.g, st.item.GetComponent<Image>().color.b, 0.5f);
                int aux = i;
                Debug.LogWarning("Aux: " + aux);
                Slot stAnterior = slotsWork[aux];
                Debug.LogWarning("stAnterior: " + stAnterior.item.name);

                st.item.GetComponent<Image>().color = new Color(st.item.GetComponent<Image>().color.r, st.item.GetComponent<Image>().color.g, st.item.GetComponent<Image>().color.b, 1f);
                do
                {
                    stAnterior.item.GetComponent<Image>().color = new Color(st.item.GetComponent<Image>().color.r, st.item.GetComponent<Image>().color.g, st.item.GetComponent<Image>().color.b, 1f);

                    aux--;
                    Debug.LogWarning("Aux: " + aux);
                    
                    stAnterior = slotsWork[aux];
                    Debug.LogWarning("stAnterior: " + stAnterior.item.name);
                    

                } while (stAnterior.item.name.CompareTo("Repetir2x") != 0);
                stAnterior.item.GetComponent<Image>().color = new Color(st.item.GetComponent<Image>().color.r, st.item.GetComponent<Image>().color.g, st.item.GetComponent<Image>().color.b, 1f);
            }

        st.item.GetComponent<Image>().color = new Color(st.item.GetComponent<Image>().color.r, st.item.GetComponent<Image>().color.g, st.item.GetComponent<Image>().color.b, 0.5f);
    }
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
