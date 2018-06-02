using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadInOut : MonoBehaviour {

    private bool aumenta;
    private Text texto;
    private float tempoanim, tempoanimbkp;

    void Start () {
        texto = GetComponent<Text>();
        aumenta = false;
        tempoanim = 3f;
        tempoanimbkp = 3f;
    }
	
	// Update is called once per frame
	void Update () {
        tempoanim -= Time.deltaTime;
        if (tempoanim <= 0)
        {
            if (aumenta)
            {
                texto.CrossFadeAlpha(1.0f, 3.0f, true);
            }
            else
            {
                texto.CrossFadeAlpha(0.0f, 3.0f, true);
            }
            aumenta = !aumenta;
            tempoanim = tempoanimbkp;
        }
    }

   
}
