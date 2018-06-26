using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleScreen : MonoBehaviour {

	public GameObject yurt;
	public GameObject note1;
	public GameObject note2;
	public GameObject note3;
	public GameObject note4;
	public float pos = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		pos += 0.004f;
		yurt.transform.position = new Vector3 (0.0f, Mathf.Sin(pos), 0.0f);

		note1.transform.position = new Vector3 (-2.0f, Mathf.Tan (pos) + 1.0f, 0.0f);
		note2.transform.position = new Vector3 (-1.0f, Mathf.Tan (pos) + 0.5f, 0.0f);
		note3.transform.position = new Vector3 (1.0f, Mathf.Tan (pos) - 0.3f, 0.0f);
		note4.transform.position = new Vector3 (2.0f, Mathf.Tan (pos) + 0.4f, 0.0f);

	}
}
