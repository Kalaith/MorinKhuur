using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScript : MonoBehaviour {

	public Image yurt;
	public Image note1;
	public Image note2;
	public Image note3;
	public Image note4;
    public Image text;
    public Image fadeToBlack;
    public GameObject fadeIntoTitle;
    public Image goButton;
    public float pos = 0.0f;
    bool fade = false;
    float alpha;
    float fadeSpeed = 0.3f;

    AudioSource audio;

    // Fade into title screen
    bool fadeTitle = false;
    float alphaTitle;
    float fadeTitleSpeed = 0.5f;
    SpriteRenderer fadeTitleSprite;

    // Use this for initialization
    void Start () {
        audio = this.GetComponent<AudioSource>();
        audio.Play();

        fadeTitle = true;

        Screen.SetResolution(800, 1280, true);

    }

    // Update is called once per frame
    void Update () {
		pos += 0.004f;
		yurt.transform.position = new Vector3 (0.0f, (Mathf.Sin(-pos)/3)+2.5f, 0.0f);

		note1.transform.position = new Vector3 (note1.transform.position.x, Mathf.Sin(-pos)/2 + 2.0f, 0.0f);
		note2.transform.position = new Vector3 (note2.transform.position.x, Mathf.Sin(pos)/3 + 2.5f, 0.0f);
		note3.transform.position = new Vector3 (note3.transform.position.x, Mathf.Sin(-pos)/3 + 3.3f, 0.0f);
		note4.transform.position = new Vector3 (note4.transform.position.x, Mathf.Sin(pos)/3 + 1.8f, 0.0f);
   
        text.transform.position = new Vector3(text.transform.position.x, Mathf.Sin(pos)/3 - 0.7f, 0.0f);
        if(fade) {
            goButton.transform.localScale = new Vector3(goButton.transform.localScale.x - ((fadeSpeed*2) * Time.deltaTime), goButton.transform.localScale.y - ((fadeSpeed*2) * Time.deltaTime), goButton.transform.localScale.z);
            audio.volume = audio.volume - (fadeSpeed * Time.deltaTime);
            alpha += fadeSpeed * Time.deltaTime;
            fadeToBlack.color = new Color(fadeToBlack.color.r, fadeToBlack.color.g, fadeToBlack.color.b, alpha);
        }

        /*if(fadeTitle) {
            alphaTitle -= fadeSpeed * Time.deltaTime;
            text.color = new Color(fadeTitleSprite.color.r, fadeTitleSprite.color.g, fadeTitleSprite.color.b, alphaTitle);
            if (alphaTitle <= 0) {
                fadeTitle = false;
            }
        }*/
    }

    public void onClick() {
        Debug.Log("onClick called");
        StartCoroutine(nextScene());
    }


    public IEnumerator nextScene() {
        fade = true;
        yield return new WaitForSeconds(4.5f);
        SceneManager.LoadScene("menu");
    }
}
