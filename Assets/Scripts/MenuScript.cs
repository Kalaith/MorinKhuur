using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuScript : MonoBehaviour {

    public GameObject[] buttonImages;
    public GameObject[] buttons;
    public Slider slide;
    public GameObject wheel;
    public float angle = 0.0f;
    Quaternion target;
    public void sliderValue()   {
        float val = slide.value;
        Debug.Log(val);
        resetButtons();

        if (val <= 0.85) {
            buttonImages[0].SetActive(false);
            buttonImages[1].SetActive(true);
            buttons[0].SetActive(true);
            target = Quaternion.Euler(0, 0, 45);
        }
        if (val > 0.85 && val <= 1.39) {
            buttonImages[2].SetActive(false);
            buttonImages[3].SetActive(true);
            buttons[1].SetActive(true);
            target = Quaternion.Euler(0, 0, 0);
        }
        if (val > 1.39 && val <= 1.95) {
            buttonImages[4].SetActive(false);
            buttonImages[5].SetActive(true);
            buttons[2].SetActive(true);
            target = Quaternion.Euler(0, 0, -45);
        }
        if (val > 1.95) {
            buttonImages[6].SetActive(false);
            buttonImages[7].SetActive(true);
            buttons[3].SetActive(true);
            target = Quaternion.Euler(0, 0, -90);
        }

        /*switch (val) {
            case 0:
                buttonImages[0].SetActive(false);
                buttonImages[1].SetActive(true);
                buttons[0].SetActive(true);
                target = Quaternion.Euler(0, 0, 45);
                break;
            case 1:
                buttonImages[2].SetActive(false);
                buttonImages[3].SetActive(true);
                buttons[1].SetActive(true);
                target = Quaternion.Euler(0, 0, 0);
                break;
            case 2:
                buttonImages[4].SetActive(false);
                buttonImages[5].SetActive(true);
                buttons[2].SetActive(true);
                target = Quaternion.Euler(0, 0, -45);
                break;
            case 3:
                buttonImages[6].SetActive(false);
                buttonImages[7].SetActive(true);
                buttons[3].SetActive(true);
                target = Quaternion.Euler(0, 0, -90);
                break;
        }*/
    }

    private void resetButtons() {
        buttons[0].SetActive(false);
        buttons[1].SetActive(false);
        buttons[2].SetActive(false);
        buttons[3].SetActive(false);

        buttonImages[0].SetActive(true);
        buttonImages[1].SetActive(false);
        buttonImages[2].SetActive(true);
        buttonImages[3].SetActive(false);
        buttonImages[4].SetActive(true);
        buttonImages[5].SetActive(false);
        buttonImages[6].SetActive(true);
        buttonImages[7].SetActive(false);

    }

    public void button1Clicked() {
        Debug.Log("button1Clicked");
        PlayerPrefs.SetString("song_choice", "song1");
        PlayerPrefs.SetString("loading", "load");
        StartCoroutine(loadScene("Loading"));
        
    }
    public void button2Clicked() {
        Debug.Log("button2Clicked");
        PlayerPrefs.SetString("song_choice", "song2");
        PlayerPrefs.SetString("loading", "load");
        StartCoroutine(loadScene("Loading"));
    }
    public void button3Clicked() {
        Debug.Log("button3Clicked");
        PlayerPrefs.SetString("song_choice", "song3");
        PlayerPrefs.SetString("loading", "load");
        StartCoroutine(loadScene("Loading"));
    }
    public void button4Clicked() {
        Debug.Log("button4Clicked");
        PlayerPrefs.SetString("loading", "credits");
        StartCoroutine(loadScene("Credits"));
    }

    public IEnumerator loadScene(string scene) {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene);
    }

    // Use this for initialization
    void Start () {
        slide.onValueChanged.AddListener(delegate { sliderValue();});
        sliderValue();

    }
	
	// Update is called once per frame
	void Update () {
        wheel.transform.rotation = Quaternion.Slerp(wheel.transform.rotation, target, Time.deltaTime);

    }

}
