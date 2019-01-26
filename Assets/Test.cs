using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            Mathf.Sin(Time.time * Mathf.PI / 4) * 5,
            1.6f,
            Mathf.Cos(Time.time * Mathf.PI / 4) * 5
        );
    }
}
