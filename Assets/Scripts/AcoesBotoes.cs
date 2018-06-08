using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AcoesBotoes : MonoBehaviour
{

    public void AcaoBotaoMainMenu(string opcao)
    {
        switch (opcao)
        {
            case "NovoJogo":
                {
                    SceneManager.LoadScene("02_NovoJogo_Entrada_Dados");
                    break;
                }
            
            case "Continuar":
                {
                    SceneManager.LoadScene("02_CarregarJogo");
                    break;
                }
            
            case "Creditos":
                {
                    Debug.Log("Creditos");
                    break;
                }
            case "Sair":
                {
                    Debug.Log("Sair");
                    break;
                }
            default:
                {
                    Debug.Log("Opção Inválida");
                    break;
                }
        }
    }

    

    public void AcaoBotaoNovoJogoEntrada_Dados(string opcao)
    {
        switch (opcao)
        {
            case "NovoJogo":
                {
                    SceneManager.LoadScene("03_01_SelectTowers");
                    break;
                }
            case "Voltar":
                {
                    SceneManager.LoadScene("01_MainMenu");
                    break;
                }

            default:
                {
                    Debug.Log("Opção Inválida");
                    break;
                }
        }
    }


    public void AcaoBotaoCarregarJogo(string opcao)
    {
        switch (opcao)
        {

            case "NovoJOp1":
                {
                    Debug.LogWarning("1");
                    SceneManager.LoadScene("04_01_towerWood_TESTE");
                    break;
                }
            case "NovoJOp2":
                {
                    //SceneManager.LoadScene("MundoMap");
                    break;
                }
            case "NovoJOp3":
                {
                    //SceneManager.LoadScene("MundoMap");
                    break;
                }
            case "Voltar":
                {
                    SceneManager.LoadScene("01_MainMenu");
                    break;
                }
            default:
                {
                    Debug.Log("Opção Inválida");
                    break;
                }
        }
    }

    public void AcaoBotaoSelectTowers(string opcao)
    {
        switch (opcao)
        {

            case "Voltar":
                {
                    SceneManager.LoadScene("02_CarregarJogo");
                    break;
                }

            case "Madeira":
                {
                    SceneManager.LoadScene("03_02_SelecaoFases");
                    break;
                }
            default:
                {
                    Debug.Log("Opção Inválida");
                    break;
                }
        }
    }


    public void AcaoBotaoSelecaoFaseWood(int i)
    {
        switch (i)
        {
            case 1:
                {
                    //SceneManager.LoadScene("04_01_towerWood");
                    SceneManager.LoadScene("04_01_towerWood_TESTE");
                    break;
                }

            case 2:
                {
                    SceneManager.LoadScene("04_02_towerWood");
                    break;
                }
            case -1:
                {
                    SceneManager.LoadScene("03_01_SelectTowers");
                    break;
                }
            default:
                {
                    Debug.Log("Opção Inválida");
                    break;
                }
        }
    }
}
