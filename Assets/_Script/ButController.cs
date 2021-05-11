using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButController : MonoBehaviour
{
    public int id;
    public GameObject panel;

    public void ButClick(){
        panel.GetComponent<PanelScript>().CheckResposta(id);
    }
}
