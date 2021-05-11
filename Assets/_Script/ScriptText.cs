using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptText : MonoBehaviour
{
    public void UpdateText(int duration, string text){
        StartCoroutine(UpdateTextIE(duration, text));
    }

    private IEnumerator UpdateTextIE(int duration, string text){
        gameObject.GetComponent<Text>().text = text;
        yield return new WaitForSeconds(duration);
        gameObject.GetComponent<Text>().text = "";
    }
}
