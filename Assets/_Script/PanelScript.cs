using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PanelScript : MonoBehaviour
{
    public bool[] resposta = new bool[] {};
    List<Transform> children = new List<Transform>();
    public bool[] filhoAtivo;

    public GameObject objAbre;

    public GameObject textPensa;
    void Start()
    {
         for (int i = 0; i < transform.childCount; i++)
         {
            children.Add(transform.GetChild(i));
            filhoAtivo[i] = false;
         }
    }

    public void CheckResposta(int id){
        filhoAtivo[id] = !filhoAtivo[id];
        if (!filhoAtivo[id])children[id].GetComponent<Image>().color = Color.HSVToRGB(0, 0, 1f);
        else children[id].GetComponent<Image>().color = Color.HSVToRGB(0, 0, .18f);
        Debug.Log(resposta);
        Debug.Log(filhoAtivo);
        if (Enumerable.SequenceEqual(filhoAtivo, resposta)){
            objAbre.GetComponent<ScriptAbre>().Abre();
            textPensa.GetComponent<ScriptText>().UpdateText(2, "Something happened");
        }
    }
}
