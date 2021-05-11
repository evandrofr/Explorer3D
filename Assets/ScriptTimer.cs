using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScriptTimer : MonoBehaviour
{
    float time;
    GameObject textPensa;
    void Start()
    {
        time = 1800;
    }

    void Update()
    {
        time -= Time.deltaTime;
        float minutes = Mathf.FloorToInt(time / 60); 
        float seconds = Mathf.FloorToInt(time % 60);

        gameObject.GetComponent<Text>().text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (time <= 0){
            SceneManager.LoadScene(3);
        }
        if (time <= 600){
            textPensa.GetComponent<ScriptText>().UpdateText(2, "I need to hurry. Only 10 minutes left");
        }
        if (time <= 1800/2){
            textPensa.GetComponent<ScriptText>().UpdateText(2, "15 minutes left!");
        }
    }
}
