using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColisorItem : MonoBehaviour {

    public Text countCoin;

    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colisão");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("10 pontos");
            int valor = int.Parse(countCoin.text);
            valor += 10;
            countCoin.text = valor.ToString();
            this.gameObject.SetActive(false);

        }
    }
}
