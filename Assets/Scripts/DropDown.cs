using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropDown : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public RectTransform container;
    public bool isOpen;

   

    // Use this for initialization
    void Start () {
        //container = transform.Find("Container").GetComponent<RectTransform>();
        isOpen = false;
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 scale = container.localScale;
        scale.x = Mathf.Lerp(scale.x, isOpen ? 1: 0, Time.deltaTime * 12);
        container.localScale = scale;

        /*if (isOpen)
        {
            Vector3 scale = container.localScale;
            scale.x = Mathf.Lerp(scale.x, 1, Time.deltaTime * 12);
            container.localScale = scale;
        }
        else
        {
            Vector3 scale = container.localScale;
            scale.x = Mathf.Lerp(scale.x, 0, Time.deltaTime * 12);
            container.localScale = scale;
        }*/
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isOpen = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOpen = false;
    }
}
