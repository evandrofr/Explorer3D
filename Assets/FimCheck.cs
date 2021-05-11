﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FimCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "Jogador"){
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(2);        
        }
    }
}
