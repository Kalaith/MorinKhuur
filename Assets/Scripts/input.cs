using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input : MonoBehaviour {

	public SphereCollider col;
	public Vector3 center;
	public Vector2 mouseVec;
	public float length; 
	public int score;

	// Use this for initialization
	void Start () {
		col = GetComponent<SphereCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		center = col.bounds.center;
		var mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		mousePos.x -= center.x;
		mousePos.y -= center.y;

		length = Mathf.Sqrt (Mathf.Pow (mousePos.x, 2) + Mathf.Pow (mousePos.y, 2));

		if (length < col.radius) {
			if (Input.GetMouseButton(0)) {
				++score;
				Debug.Log (score);
			} 
		}
	}
}
