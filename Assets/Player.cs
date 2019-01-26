using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool up = true;
    bool down = true;
    bool left = true;
    bool right = true;

    float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            up = true;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow)) {
            up = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            down = true;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow)) {
            down = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            left = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow)) {
            left = false;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            right = true;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow)) {
            right = false;
        }

        if(up) transform.Translate(0, 0, Time.deltaTime * speed);
        if(down) transform.Translate(0, 0, - Time.deltaTime * speed);
        if(left) transform.Translate(Time.deltaTime * speed, 0, 0);
        if(right) transform.Translate(-Time.deltaTime * speed, 0, 0);
        
    }
}
