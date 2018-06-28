using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class LoadSong : MonoBehaviour {
    public bool loading = true;
    public string songName;
    public string filepath;
    public int bpm = 0; // beats per minute
    public int noteFrequency = 1;

    public List<float?> notes;
    private int noteCount = 0;
    private int score;

    public float? getNote() {
        //Debug.Log(noteCount +":"+notes.Count);
        if(noteCount >= notes.Count) {
            return null;
        }
        return notes[noteCount++]; 
    }

    public bool loadSong(TextAsset file) {
        loading = true;
        // Handle any problems that might arise when reading the text
        try {
            notes = new List<float?>();
            noteCount = 0;

            string fs = file.text;
            string[] fLines = Regex.Split(fs, "\r\n");


            string[] entries;
            entries = fLines[0].Split(':');
            songName = entries[1];
            Debug.Log("Song Name from File:"+songName);

            entries = fLines[1].Split(':');
            filepath = entries[1];

            entries = fLines[2].Split(':');
            int.TryParse(entries[1], out bpm);

            entries = fLines[3].Split(':');
            int.TryParse(entries[1], out noteFrequency);

            for (int i = 4; i < fLines.Length; i++) {

                string line = fLines[i];
                if (line != null) {
                    if (line.Length == 0) {
                        notes.Add(null);
                    } else {
                        score++;
                        notes.Add(float.Parse(line));
                        //Debug.Log("Line:"+line);
                    }
                }
            }
        } catch (System.Exception e) {
            return false;
        }
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("max_score", score);
        loading = false;
        return true;
    }

}
