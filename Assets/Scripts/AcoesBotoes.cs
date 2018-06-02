using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AcoesBotoes : MonoBehaviour
{

    public void AcaoBotao(string opcao)
    {
        switch (opcao)
        {
            case "NovoJ":
                {
                    SceneManager.LoadScene("NovoJogo");
                    break;
                }
            case "NovoJOp1":
                {
                    SceneManager.LoadScene("MundoMap");
                    break;
                }
            case "NovoJOp2":
                {
                    SceneManager.LoadScene("MundoMap");
                    break;
                }
            case "NovoJOp3":
                {
                    SceneManager.LoadScene("MundoMap");
                    break;
                }
            case "Continuar":
                {
                    SceneManager.LoadScene("Continue");
                    break;
                }
            case "ContinuarOp1":
                {
                    SceneManager.LoadScene("FaseAlpha1");
                    break;
                }
            case "ContinuarOp2":
                {
                    SceneManager.LoadScene("FaseAlpha1");
                    break;
                }
            case "ContinuarOp3":
                {
                    SceneManager.LoadScene("FaseAlpha1");
                    break;
                }

            case "FasesAlpha":
                {
                    SceneManager.LoadScene("FaseAlpha");
                    break;
                }
            case "FasesBeta":
                {
                    SceneManager.LoadScene("FaseBeta");
                    break;
                }
            case "FasesDelta":
                {
                    SceneManager.LoadScene("FaseGama");
                    break;
                }
            case "FasesZeta":
                {
                    SceneManager.LoadScene("FaseZeta");
                    break;
                }
            default:
                {
                    Debug.Log("Opção Inválida");
                    break;
                }
        }
    }

    public void FaseAlpha(int i)
    {
        switch (i)
        {
            case 1:
                {
                    SceneManager.LoadScene("FaseAlpha1");
                    break;
                }

            case 2:
                {
                    SceneManager.LoadScene("FaseAlpha1");
                    break;
                }
            default:
                {
                    Debug.Log("Inicia a default");
                    break;
                }
        }
    }
}
