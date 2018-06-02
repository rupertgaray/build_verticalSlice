using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaminhoCena : MonoBehaviour {

    // Use this for initialization
	void Start () {
        Scene cena = SceneManager.GetActiveScene();
        Debug.Log(cena.path);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
