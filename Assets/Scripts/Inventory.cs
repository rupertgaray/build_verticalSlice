using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory : MonoBehaviour, IHasChanged
{

    [SerializeField] public Transform slots;
    private string texto;
    

    void Start()
    {
        HasChanged();
    }

    #region IHasChanged implementation
    public void HasChanged()
    {
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        //builder.Append(" - ");
        foreach (Transform slotTransform in slots)
        {
            GameObject item = slotTransform.GetComponent<Slot>().item;
            if (item)
            {
                builder.Append(item.name);
                builder.Append(" - ");
            }
        }
        texto = builder.ToString();
        //Debug.Log(texto);
        ListarMovimentos();
    }
    #endregion

    public string[] ListarMovimentos()
    {
        string[] mov = texto.Split('-');
        /*foreach(string word in mov)
        {
            Debug.Log(word);
        }*/
        
        return mov;
    }
}


namespace UnityEngine.EventSystems
{
    public interface IHasChanged : IEventSystemHandler
    {
        void HasChanged();
    }
}