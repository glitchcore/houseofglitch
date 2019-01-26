using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool up = false;
    bool down = false;
    bool left = false;
    bool right = false;

    public float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) {
            up = true;
        }
        if (Input.GetKeyUp(KeyCode.W)) {
            up = false;
        }

        if (Input.GetKeyDown(KeyCode.S)) {
            down = true;
        }
        if (Input.GetKeyUp(KeyCode.S)) {
            down = false;
        }

        if (Input.GetKeyDown(KeyCode.A)) {
            left = true;
        }
        if (Input.GetKeyUp(KeyCode.A)) {
            left = false;
        }

        if (Input.GetKeyDown(KeyCode.D)) {
            right = true;
        }
        if (Input.GetKeyUp(KeyCode.D)) {
            right = false;
        }

        /*
        if(up) transform.Translate(0, 0, Time.deltaTime * speed);
        if(down) transform.Translate(0, 0, - Time.deltaTime * speed);
        if(left) transform.Translate(Time.deltaTime * speed, 0, 0);
        if(right) transform.Translate(-Time.deltaTime * speed, 0, 0);
        */

        if(up) {
            transform.position = transform.position + Camera.main.transform.forward * 5f * Time.deltaTime;
        }

        if(down) {
            transform.position = transform.position - Camera.main.transform.forward * 5f * Time.deltaTime;
        }
        
    }
}
