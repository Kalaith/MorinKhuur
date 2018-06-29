using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trail : MonoBehaviour {


	public float pos_x = 0.0f; 
	public float pos_y; 
	public float musicTicks;
	public int[] ticksg = {
		1, 2, 1, 2, 
		2, 1, 2, 1, 
		2, 2, 1, 1,
		1, 1, 1, 2, 
		2, 2, 2, 2, 
		2, 2, 1, 2, 
		1, 2, 1, 2
	};

	public AudioSource audioSource;
	public AudioClip audio;

	// Use this for initialization
	void Start () {
		audioSource.GetComponent<AudioSource> ();
		audioSource.PlayOneShot (audio, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.RightArrow))
		{
			pos_x += 0.1f;	
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			pos_x -= 0.1f;	
		}

		int index = (int)Mathf.Abs(Time.realtimeSinceStartup);	

		if(ticksg[index] == 1) {
			pos_x += 0.03f; 
		}
		if (ticksg[index] == 2 ) {
			pos_x -= 0.03f; 
		}

		pos_y += -0.01f;

		transform.position = new Vector3(pos_x, pos_y, 0.0f);
	}
}
