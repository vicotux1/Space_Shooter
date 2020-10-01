using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class sound : MonoBehaviour{
    [Header("Menu Opciones")]
    public AudioMixer audiomixer;
	 
	public Slider fxSound,MusicSound; 
    public float sfxVolume, MusicVolume;
    
	public void FxSounds(float Fxvolumen){
        audiomixer.SetFloat("sfxVolumen",Fxvolumen) ;//Aplicar volumen
    }
    public void MusicSounds(float Musicvolumen){
       audiomixer.SetFloat("musicVolumen",Musicvolumen) ;
    }
    void Awake(){
        LoadData();
        }
        public void cursortrue(){
		Cursor.visible = true;
        }
   public void setResolution (int setResolution){
		if(setResolution==1){
		 Screen.SetResolution(848, 480, false);
			}if(setResolution==0){
		 Screen.SetResolution(1024, 600, false);
			}
			if(setResolution==2){
		 Screen.SetResolution(1280, 720, false);
			}
			if(setResolution==3){
		 Screen.SetResolution(1920, 1080, false);
			}
			Debug.Log("SetResolution "+setResolution);
		}
   public void antiAliasing_Quality (int Level){
	QualitySettings.antiAliasing = Level;
	Debug.Log("antiAliasing level "+Level);
	}

    private void OnDestroy(){
    SaveData();
    }


    public void SaveData()
    {
        //volumen de efectos de sonido.
        audiomixer.GetFloat("Fxvolumen", out sfxVolume);
        audiomixer.GetFloat("Soundvolumen", out MusicVolume);
        //volumen de Musica de fondo.
        PlayerPrefs.SetFloat("MusicVolumen",MusicVolume);
        PlayerPrefs.SetFloat("SFXVolumen",sfxVolume);
        Debug.Log("Datos guardados");
    }


	public void LoadData()
    {
        sfxVolume = PlayerPrefs.GetFloat("SFXVolumen",sfxVolume);
        MusicVolume = PlayerPrefs.GetFloat("MusicVolumen",MusicVolume);
        IniciarIndicadores(sfxVolume,MusicVolume);
        AplicarCambios(sfxVolume,MusicVolume);
        
    }

    private void IniciarIndicadores(float Sfx, float Music){
        fxSound.value = Sfx;
        MusicSound.value = Music;
        
    }

    private void AplicarCambios(float Sfx, float Music){
        FxSounds(Sfx);
        MusicSounds(Music);
    Debug.Log("Datos cargados");
    }


}
