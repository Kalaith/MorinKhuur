using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoteController : MonoBehaviour {

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
    public AudioClip clip;
    public bool paused;
    public GameObject pauseMenu;

    public GameObject noteHolder;

    bool gameWon;
    bool gameOver;

    // Use this for initialization
    void Start() {
        Debug.Log(PlayerPrefs.GetString("song_choice"));

        ls = new LoadSong();

        string songChoice = "assets/resources/" + PlayerPrefs.GetString("song_choice") + ".txt";
        ls.loadSong(songChoice);

        clip = Resources.Load(ls.filepath, typeof(AudioClip)) as AudioClip;
        //clip = Resources.Load("S1 test") as AudioClip;
        Debug.Log("Filepath: " + ls.filepath);

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

    // Update is called once per frame
    void Update() {
        timeRemaining += Time.deltaTime;
        if (timeRemaining > interval) {

            timeRemaining = 0;
            float? note = ls.getNote();
            if (note != null) {

                createNote("Note" + (song.time), ((float)note - 2.5f), 5.5f, 0, -1.4f, Note.direction.DOWN, Note.noteType.SHORT);

            }
        }


        if(song.time > 0) {
            timeR = song.clip.length - song.time;
        }

        Debug.Log("TimeLeft"+(timeR));

        if (timeR== 0) {
            gameWon = true;
            // Enable the game won screen, set prefs return to game.
            Debug.Log("Game Won, Congrats");
            pauseGame();
        }

        if (Input.GetKeyDown("p") && paused) {
            resumeGame();
        } else if (Input.GetKeyDown("p") && !paused) {
            pauseGame();
        }



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
        SceneManager.LoadScene("Menu");
    }
}
