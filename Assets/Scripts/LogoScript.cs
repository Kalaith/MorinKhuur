using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(loadMenu());

        // TODO move scene after x seconds
    }

    private IEnumerator loadMenu()
    {
        DontDestroyOnLoad((GameObject)Resources.Load("PlayerGO"));
        Debug.Log("Menu");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Menu");
        Debug.Log("EndMenu");


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
