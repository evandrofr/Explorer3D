using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAbre : MonoBehaviour{

    public AudioClip openSFX;
    public GameObject itemAbre, player;
    public bool abre = false;
    private void OnCollisionEnter(Collision other) {
        if (itemAbre != null && other.gameObject == itemAbre){
            Destroy(itemAbre);
            Abre();
        }
    }

    public void Abre(){
        abre = true;
        AudioManager.PlaySFX(openSFX);
        gameObject.GetComponent<Animator>().SetTrigger("Abre");
        player.GetComponent<PlayerController>().segurando = false;
        transform.tag = "Aberto";
    }
}
