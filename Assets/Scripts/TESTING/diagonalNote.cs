using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diagonalNote : MonoBehaviour
{

    public float fallingSpeed;
    public int i = 0;
    public GameObject touchBar;
    bool mouseDown = false;
    private bool touchable;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, fallingSpeed * Time.deltaTime, 0);
        SpriteRenderer s = GetComponent<SpriteRenderer>();
        SpriteRenderer tb = touchBar.GetComponent<SpriteRenderer>();

        if (Input.GetMouseButtonDown(0))
        {
            mouseDown = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
        }

        //  Debug.Log("min " + s.bounds.min.y+" Max "+s.bounds.max.y);

        if (mouseDown && touchable)
        {

            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit.collider != null && hit.collider.name == "DiagonalNote")
            {
                Debug.Log("Diagonal note if in a valid hit position and we are touching it"+ hit.collider.name);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("triggered");
        touchable = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        touchable = false;
        Debug.Log("remove object");
    }
}
