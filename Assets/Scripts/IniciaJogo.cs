using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IniciaJogo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.anyKey)
        /*if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
        {
            //Debug.Log("Enter pressionado");
            ProximaCena();
        }*/
        if (Input.anyKey)
        {
            //Debug.Log("Enter pressionado");
            ProximaCena();
        }

    }

    private void ProximaCena()
    {
        SceneManager.LoadScene("01_MainMenu");
    }
}