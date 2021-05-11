using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolumeSFX : MonoBehaviour{

    public AudioMixer mixer;

    public void SetLevel (float sliderValue){
        mixer.SetFloat("SFXVol", Mathf.Log10(sliderValue) * 20);
    }

}
