using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class longNotesScript : MonoBehaviour {

    public float fallingSpeed;
    public int i = 0;
    public GameObject touchBar;
    bool mouseDown = false;
    float startx;
    float endx;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(0, fallingSpeed * Time.deltaTime, 0);
        SpriteRenderer s = GetComponent<SpriteRenderer>();
        SpriteRenderer tb = touchBar.GetComponent<SpriteRenderer>();

        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            mouseDown = true;
            startx = position.x;
        }
        if(Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
            endx = position.x;
            //Debug.Log("StartX"+startx+" endx"+endx);
        }

      //  Debug.Log("min " + s.bounds.min.y+" Max "+s.bounds.max.y);

        if (mouseDown)
        {
            
            
            if (position.x > s.bounds.min.x && position.x < s.bounds.max.x)
            {
                if (position.y > s.bounds.min.y && position.y < s.bounds.max.y)
                {
                    
                    if (s.bounds.min.y < tb.bounds.max.y)
                    {

                        Debug.Log(i);
                        i++;

                    } 
                }

            }

        }
    }
}
