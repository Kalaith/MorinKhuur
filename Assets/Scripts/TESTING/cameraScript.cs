using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {

	public float cameraSpeed = -0.01f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position -= new Vector3(0.0f, cameraSpeed * Time.deltaTime, 0.0f);
	}
}
