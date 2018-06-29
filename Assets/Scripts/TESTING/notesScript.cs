using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notesScript : MonoBehaviour {

    public float fallingSpeed;
    public GameObject touchBar;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(0,fallingSpeed * Time.deltaTime, 0);
        SpriteRenderer s = GetComponent<SpriteRenderer>();
        SpriteRenderer tb = touchBar.GetComponent<SpriteRenderer>();

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log("x"+ position.x+"y"+ position.y);
            //Debug.Log("x" + Input.mousePosition.x + "y" + Input.mousePosition.y);
            if (position.x > s.bounds.min.x && position.x < s.bounds.max.x)
            {
                if (position.y > s.bounds.min.y && position.y < s.bounds.max.y)
                {
                    //Debug.Log("In\n");
                    if(s.bounds.max.y > tb.bounds.min.y && s.bounds.max.y < tb.bounds.max.y)
                    {
                        
                         Debug.Log("Y");
                        
                    }
                }

            }

        }

    }
}
