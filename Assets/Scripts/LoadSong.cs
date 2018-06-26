using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadSong : ScriptableObject {

    public string songName;
    public string filepath;
    public int bpm = 0; // beats per minute
    public int noteFrequency = 1;

    public List<float?> notes;
    private int noteCount = 0;

    public float? getNote() {
        //Debug.Log(noteCount +":"+notes.Count);
        if(noteCount >= notes.Count) {
            noteCount = 0;

        }
        return notes[noteCount++]; 
    }

    public bool loadSong(string filename) {
        // Handle any problems that might arise when reading the text
        try {
            string line;

            StreamReader theReader = new StreamReader(filename);
            notes = new List<float?>();
            noteCount = 0;
            using (theReader) {
                string[] entries;
                line = theReader.ReadLine();
                entries = line.Split(':');
                songName = entries[1];
                //Debug.Log("songName: "+songName);

                line = theReader.ReadLine();
                entries = line.Split(':');
                filepath = entries[1];
                //Debug.Log("filepath: " + filepath);

                line = theReader.ReadLine();
                entries = line.Split(':');
                int.TryParse(entries[1], out bpm);
                //Debug.Log("bpm: " + bpm);

                line = theReader.ReadLine();
                entries = line.Split(':');
                int.TryParse(entries[1], out noteFrequency);
                //Debug.Log("noteF: " + noteFrequency);

                // While there's lines left in the text file, do this:
                do {
                    line = theReader.ReadLine();
                    if (line.Length == 0) {
                        notes.Add(null);
                    } else {
                        notes.Add(float.Parse(line));
                        //Debug.Log("Line:"+line);
                    }
                    
                }
                while (line != null);
                // Done reading, close the reader and return true to broadcast success    
                theReader.Close();
            }
        } catch (System.Exception e) {
            Debug.Log("Load file error: "+e);
        }
        return true;
    }

}
