using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class NoteController : MonoBehaviour {

    // Clip when won
    public AudioClip winClip;
    public Sprite[] mkSprites;
    public Image selectedMK;
    // Clips and Files for each song, set in 
    public AudioClip songClip1;
    public AudioClip songClip2;
    public AudioClip songClip3;
    public TextAsset lsFile1;
    public TextAsset lsFile2;
    public TextAsset lsFile3;

    public Image bgMusic;

    public Text scoreText;

    public enum DIFFICULTY { EASY = 0, MEDIUMN = 1, HARD = 2 };
    public AudioSource song;
    public float timeRemaining;
    float timeR;
    int r;

    DateTime LastSpawned;
    const float interval = 0.357f;//half beat
    const float beat = 0.714f;
    const int fallDistance = 10;
    const float fallSpeed = -1.4f;
    public int noteCount = 0;
    private LoadSong ls;

    public bool paused;
    public GameObject pauseMenu;
    private AudioClip clip;
    public GameObject noteHolder;
    public GameObject winScreen;

    bool gameWon;
    bool gameOver;
    private bool highScore;
    private float pos;

    // Use this for initialization
    void Start() {
        startGame();
    }

    private void startGame() {
        selectedMK.sprite = mkSprites[PlayerPrefs.GetInt("skin")];
        Debug.Log(PlayerPrefs.GetString("song_choice"));
        TextAsset lsFile = null;
        ls = new LoadSong();
        string songChoice = PlayerPrefs.GetString("song_choice");
        if(songChoice.Equals("song1")) {
            clip = songClip1;
            lsFile = lsFile1;
        }
        if (songChoice.Equals("song2")) {
            clip = songClip2;
            lsFile = lsFile2;
        }
        if (songChoice.Equals("song3")) {
            clip = songClip3;
            lsFile = lsFile3;
        }
  
        ls.loadSong(lsFile);
        //clip = Resources.Load(ls.filePath, typeof(AudioClip)) as AudioClip;
        //text.text = "Path:" + ls.filepath;

        //clip = Resources.Load("S1 test") as AudioClip;
        Debug.Log("Filepath: " + ls.filepath);
        clip.LoadAudioData();
        do {
            Debug.Log("Loading Song Clip");
        } while (clip.loadState != AudioDataLoadState.Loaded);

        song = GetComponent<AudioSource>();
        song.clip = clip;

        paused = false;
        timeR = song.clip.length;
        //song.time = song.clip.length - 10;
        song.Play();
    }

    private void createNote(string v1, float v2, float v3, int v4, float v5, Note.direction dir, Note.noteType type) {
        GameObject noteGO = GameObject.Instantiate((GameObject)Resources.Load("NotePrefab"));
        noteGO.transform.SetParent(noteHolder.transform);

        Note noteS = noteGO.GetComponent<Note>();
        
        noteS.initNote(v1, v2, v3, v4, v5, dir, type);
    }
    float rotSpeed = 0.5f;
    // Update is called once per frame
    void Update() {

        bgMusic.transform.position = new Vector3(bgMusic.transform.position.x, (Mathf.Sin(pos) / 3), bgMusic.transform.position.z);
        bgMusic.transform.Rotate(0, 0, rotSpeed * Time.deltaTime, 0);
        pos += 0.004f;

        timeRemaining += Time.deltaTime;
        if (timeRemaining > interval) {

            timeRemaining = 0;
            float? note = ls.getNote();
            if (note != null) {
                if (PlayerPrefs.GetString("song_choice") == "song1") {
                    createNote("Note" + (song.time), ((float)note - 2.5f), 5.5f, 0, -1.4f, Note.direction.DOWN, Note.noteType.SHORT);
                }
                if (PlayerPrefs.GetString("song_choice") == "song2") {
                    createNote("Note" + (song.time), ((float)note - 2.5f), 5.5f, 0, -1.0f, Note.direction.DOWN, Note.noteType.SHORT);
                }
                if (PlayerPrefs.GetString("song_choice") == "song3") {
                    createNote("Note" + (song.time), ((float)note - 2.5f), 5.5f, 0, -2.96f, Note.direction.DOWN, Note.noteType.SHORT);

                }
                //createNote("Note" + (song.time), ((float)note - 2.5f), 5.5f, 0, -1.4f, Note.direction.DOWN, Note.noteType.SHORT);
            }
        }


        if(song.time > 0) {
            timeR = song.clip.length - song.time;
        }

        //Debug.Log("TimeLeft"+(timeR));

        if (timeR < 0.01 && !gameWon) {
            song.clip = winClip;
            song.Play(0);
            gameWon = true;
            // Enable the game won screen, set prefs return to game.
            Debug.Log("Game Won, Congrats");
            Debug.Log("High Score" +PlayerPrefs.GetInt("high_score_" + PlayerPrefs.GetInt("song_choice")));
            Debug.Log("Score"+ PlayerPrefs.GetInt("score"));
            Debug.Log("Max Score" + PlayerPrefs.GetInt("max_score"));

            int score = PlayerPrefs.GetInt("score") - PlayerPrefs.GetInt("max_score");
            if (PlayerPrefs.GetInt("score") > PlayerPrefs.GetInt("high_score_"+PlayerPrefs.GetInt("song_choice"))) {
                PlayerPrefs.SetInt("high_score_" + PlayerPrefs.GetInt("song_choice"), PlayerPrefs.GetInt("score"));
                highScore = true;
            }

            if(highScore) {
                scoreText.text = "Score: " + PlayerPrefs.GetInt("score") + "/" + PlayerPrefs.GetInt("max_score")+" <b>* NEW RECORD</b>";
            } else {
                scoreText.text = "Score: " + PlayerPrefs.GetInt("score") + "/" + PlayerPrefs.GetInt("max_score"); 
            }

            paused = true;
            Time.timeScale = 0.0f;
            winScreen.SetActive(true);

        }

        if (Input.GetKeyDown("p") && paused) {
            resumeGame();
        } else if (Input.GetKeyDown("p") && !paused) {
            pauseGame();
        }



    }

    public void restart() {
        paused = false;
        gameWon = false;
        Time.timeScale = 1;

        // Find all notes and destroy them before restarting
        GameObject[] notes = GameObject.FindGameObjectsWithTag("Note");

        foreach(GameObject note in notes) {

            Destroy(note);

        }
        winScreen.SetActive(false);

        startGame();
    }

    public void pauseGame() {
        paused = true;
        Time.timeScale = 0.0f;
        song.Pause();
        pauseMenu.SetActive(true);
    }

    public void resumeGame() {
        paused = false;
        Time.timeScale = 1;
        song.Play();
        pauseMenu.SetActive(false);
    }

    public void exitGame() {
        ls = null;
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
