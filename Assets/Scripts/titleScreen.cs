using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleScreen : MonoBehaviour {

	public GameObject yurt;
	public GameObject note1;
	public GameObject note2;
	public GameObject note3;
	public GameObject note4;
    public GameObject text;
    public GameObject fadeToBlack;
    public GameObject fadeIntoTitle;
    public float pos = 0.0f;
    bool fade = false;
    float alpha;
    float fadeSpeed = 0.3f;
    SpriteRenderer fadeSprite;

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

        fadeSprite = fadeToBlack.GetComponent<SpriteRenderer>();
        fadeTitleSprite = fadeIntoTitle.GetComponent<SpriteRenderer>();

        fadeTitle = true;

    }

    // Update is called once per frame
    void Update () {
		pos += 0.004f;
		yurt.transform.position = new Vector3 (0.0f, (Mathf.Sin(pos)/6)+2.5f, 0.0f);

		note1.transform.position = new Vector3 (-2.0f, Mathf.Sin(-pos)/2 + 1.0f, 0.0f);
		note2.transform.position = new Vector3 (-1.0f, Mathf.Sin(pos)/4 + 0.5f, 0.0f);
		note3.transform.position = new Vector3 (1.0f, Mathf.Sin(-pos)/3 - 0.3f, 0.0f);
		note4.transform.position = new Vector3 (2.0f, Mathf.Sin(pos) + 0.4f, 0.0f);

        text.transform.position = new Vector3(0.6f, Mathf.Sin(pos)/6 - 1.6f, 0.0f);
        if(fade) {
            alpha += fadeSpeed * Time.deltaTime;
            fadeSprite.color = new Color(fadeSprite.color.r, fadeSprite.color.g, fadeSprite.color.b, alpha);
        }

        if(fadeTitle) {
            alphaTitle -= fadeSpeed * Time.deltaTime;
            fadeTitleSprite.color = new Color(fadeTitleSprite.color.r, fadeTitleSprite.color.g, fadeTitleSprite.color.b, alphaTitle);
            if (alphaTitle <= 0) {
                fadeTitle = false;
            }

        }
    }

    public void onClick() {
        StartCoroutine(nextScene());
    }


    public IEnumerator nextScene() {
        fade = true;
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("menu");
    }
}
