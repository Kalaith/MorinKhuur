using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SongSelectScript : MonoBehaviour {

    public Image[] buttonImages;
    AudioSource audio;
    public AudioClip selectSound;

	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();

        resetButtons();
        string choice = PlayerPrefs.GetString("song_choice");
        Debug.Log("choice"+choice);
        switch (choice) { 
            case "song1":
                setSong1();
                break;
            case "song2":
                setSong2();
                break;
            case "song3":
                setSong3();
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setSong1() {
        //audio.PlayOneShot(selectSound);
        resetButtons();
        PlayerPrefs.SetString("song_choice", "song1");
        buttonImages[4].enabled = true;
        buttonImages[5].enabled = false;
        //Debug.Log("choice1");
    }
    public void setSong2() {
        //audio.PlayOneShot(selectSound);
        resetButtons();
        PlayerPrefs.SetString("song_choice", "song2");
        buttonImages[3].enabled = false;
        buttonImages[2].enabled = true;
        //Debug.Log("choice2");
    }
    public void setSong3() {
        //audio.PlayOneShot(selectSound);
        resetButtons();
        PlayerPrefs.SetString("song_choice", "song3");
        buttonImages[0].enabled = true;
        buttonImages[1].enabled = false;
        //Debug.Log("choice3");
    }
    public void resetButtons() {
        foreach(Image image in buttonImages) {
            image.enabled = false;
        }
        buttonImages[1].enabled = true;
        buttonImages[3].enabled = true;
        buttonImages[5].enabled = true;
    }


    public void backToMenu() {
        SceneManager.LoadScene("Menu");
    }
}
