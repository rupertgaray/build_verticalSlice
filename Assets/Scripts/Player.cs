using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int vidas, pontos;
    
	void Awake () {
        vidas = 3;
        pontos = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    enum Moviemntos
    {
        Andando,
        Pulando,
        Parado,
        Quebrando
    };
}
