using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float fallingSpeed;
    bool mouseDown = false;
    private bool touchable;

    private float Width;
    private float Height;
    private float Rotation;
    private string Name;
    public enum direction { LEFT = 0, RIGHT = 1, UP = 2, DOWN = 3};
    private direction Direction; // 1 left, 2 right, 3 up, 4 down

    public enum noteType { SHORT = 0, LONG = 1}
    private noteType Type;
    public void initNote(string n, float width, float height, float rotation, float fs, direction dir, noteType nt)
    {
        Name = n;
        this.name = n;
        this.tag = "Note";
        this.transform.SetPositionAndRotation(new Vector3(width, height, -5), Quaternion.Euler(0, 0, rotation));
        this.transform.localScale = new Vector3(0.4f, 0.4f, 1f);
        Width = width;
        Height = height;
        Rotation = rotation;
        Direction = dir;
        Type = nt;
        fallingSpeed = fs;

        // Modify the game object passed on the information passed in.
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, fallingSpeed * Time.deltaTime, 0);

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

            if (hit.collider != null && hit.collider.name == Name)
            {
                Debug.Log("Correct " + hit.collider.name);
                Destroy(gameObject);
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
        Destroy(gameObject);
    }
}
