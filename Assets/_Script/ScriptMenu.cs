using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptMenu : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject menuPanel;
    public void LoadNextScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Quit(){
        Application.Quit();
    }
    public void OpenOptions(){
        optionsPanel.gameObject.SetActive(true);
        menuPanel.gameObject.SetActive(false);
    }
    public void CloseOptions(){
        optionsPanel.gameObject.SetActive(false);
        menuPanel.gameObject.SetActive(true);
    }
    public void LoadMenu(){
        SceneManager.LoadScene(0);
    }
}
