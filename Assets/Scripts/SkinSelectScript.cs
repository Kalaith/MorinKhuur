﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkinSelectScript : MonoBehaviour {

    public Sprite[] sprites;
    public Image selectedSkin;
    public int skinSelect = 0;
    public int maxSkins = 0;

    AudioSource audio;
    public AudioClip drumSound;
    public AudioClip stringSound;

    // Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();

        skinSelect = PlayerPrefs.GetInt("skin");
        selectedSkin.sprite = sprites[skinSelect];

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changeSkin(int dir) {
        skinSelect = skinSelect + dir;
        if(skinSelect > maxSkins) {
            skinSelect = 0;
        }

        if (skinSelect < 0) {
            skinSelect = maxSkins;
        }
        PlayerPrefs.SetInt("skin", skinSelect);
        selectedSkin.sprite = sprites[skinSelect];
    }

    public void moveToMenu() {
        PlayerPrefs.SetInt("skin", skinSelect);
        SceneManager.LoadScene("Menu");
    }

    public void backToMenu() {
        audio.PlayOneShot(drumSound);
        Invoke("moveToMenu", 2.2f);
    }
}
