using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public GameObject wheel;
    public bool startRotation = false;
    public bool rotationFinished = true;
    public float rotation = 180;
    public float dampen = 0.5f;

    // 

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(startRotation)
        {
            Quaternion target = Quaternion.Euler(0, 0, rotation);

            // Dampen towards the target rotation
            wheel.transform.rotation = Quaternion.Slerp(wheel.transform.rotation, target, Time.deltaTime);
        }
	}

    public void loadMenu()
    {
        if (rotationFinished == true)
        {
            rotation = 90;
            startRotation = true;
        }
    }

    // rotate the wheel then load the game
    public void startGame()
    {
        if (rotationFinished == true)
        {
            rotation = 180;
            startRotation = true;
        }

        //yield return new WaitForSeconds(3);
        PlayerPrefs.SetString("song_choice", "song1");
        SceneManager.LoadScene("Game");
    }

    // After start is pressed we want to rotate 1 degree every frame to 180, after the rotation has finished we display the difficulty
}
