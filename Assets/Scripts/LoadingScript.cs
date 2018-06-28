using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour {

    public GameObject Background;
    public GameObject Foreground;
    public GameObject Buildings;

    public float bgSpeed;
    public float fgSpeed;
    public float buildSpeed;

	AudioSource audio;
	public AudioClip song; 

	// Use this for initialization
	void Start () {
		audio = this.GetComponent<AudioSource> ();
		audio.loop = true;
		audio.Play ();

        string mode = PlayerPrefs.GetString("loading");
        //Debug.Log("Mode: "+mode);
        if(mode.Equals("credits")) {
            StartCoroutine(loadCredits());
            //Debug.Log("Credits: " + mode);
        }
        else if (mode.Equals("load")) {
            StartCoroutine(loadGame());
        }

    }

    public IEnumerator loadCredits() {
        yield return new WaitForSeconds(45);
        SceneManager.LoadScene("Menu");
    }

    public IEnumerator loadGame() {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Game");
    }
	
	// Update is called once per frame
	void Update () {
        Background.transform.position = new Vector3(Background.transform.position.x-(bgSpeed*Time.deltaTime), Background.transform.position.y, Background.transform.position.z);
        Foreground.transform.position = new Vector3(Foreground.transform.position.x - (fgSpeed * Time.deltaTime), Foreground.transform.position.y, Foreground.transform.position.z);
        Buildings.transform.position = new Vector3(Buildings.transform.position.x - (buildSpeed * Time.deltaTime), Buildings.transform.position.y, Buildings.transform.position.z);
    }
}
