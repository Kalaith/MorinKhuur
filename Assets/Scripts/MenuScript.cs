using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuScript : MonoBehaviour {

    public GameObject[] buttons;
    public Slider slide;
    public GameObject wheel;
    public float angle = 0.0f;
    Quaternion target;
    public void sliderValue()   {
        int val = (int)slide.value;
        Debug.Log(val);
        resetAnim();

        switch (val) {
            case 0:
                buttons[0].SetActive(false);
                buttons[1].SetActive(true);
                target = Quaternion.Euler(0,0,45);
                break;
            case 1:
                buttons[2].SetActive(false);
                buttons[3].SetActive(true);
                target = Quaternion.Euler(0, 0, 0);
                break;
            case 2:
                buttons[4].SetActive(false);
                buttons[5].SetActive(true);
                target = Quaternion.Euler(0, 0, -45);
                break;
            case 3:
                buttons[6].SetActive(false);
                buttons[7].SetActive(true);
                target = Quaternion.Euler(0, 0, -90);
                break;
        }
    }

    private void resetAnim() {
        buttons[0].SetActive(true);
        buttons[1].SetActive(false);
        buttons[2].SetActive(true);
        buttons[3].SetActive(false);
        buttons[4].SetActive(true);
        buttons[5].SetActive(false);
        buttons[6].SetActive(true);
        buttons[7].SetActive(false);

    }
    
    // Use this for initialization
	void Start () {
        slide.onValueChanged.AddListener(delegate { sliderValue();});
        sliderValue();

    }
	
	// Update is called once per frame
	void Update () {
        wheel.transform.rotation = Quaternion.Slerp(wheel.transform.rotation, target, Time.deltaTime);

    }

}
