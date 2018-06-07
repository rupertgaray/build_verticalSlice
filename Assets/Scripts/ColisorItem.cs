using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColisorItem : MonoBehaviour {

    private GameObject txt;
    private Text textUI;

    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(this.gameObject.tag == "Coin")
            {
                txt = GameObject.FindGameObjectWithTag("CountCoin");
                textUI = txt.GetComponent<Text>();
                Debug.Log("10 pontos");
                int valor = int.Parse(textUI.text);
                valor += 10;
                textUI.text = valor.ToString();
                this.gameObject.SetActive(false);
            }
            else if (this.gameObject.tag == "Star")
            {
                txt = GameObject.FindGameObjectWithTag("CountStar");
                textUI = txt.GetComponent<Text>();
                Debug.Log("1 estrela");

                var array = textUI.text.Split('/');

                int valor = int.Parse(array[0]);
                valor += 1;
                textUI.text = valor.ToString() + "/" + array[1];
                this.gameObject.SetActive(false);
            }
            else if (this.gameObject.tag == "Cristal")
            {
                txt = GameObject.FindGameObjectWithTag("CountCristal");
                textUI = txt.GetComponent<Text>();
                Debug.Log("1 cristal");

                int valor = int.Parse(textUI.text);
                valor += 1;
                textUI.text = valor.ToString();
                this.gameObject.SetActive(false);


            }

        }

    }
}
