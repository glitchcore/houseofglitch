using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    public float freq = 440.0f;
    public float spread = 0.75f;
    public float gain = 0.25f;

    private double phase;
    private double fs = 48000.0;
    private double increment;

    

    void OnAudioFilterRead(float[] data, int channels) {
        for(int i = 0; i < data.Length; i += channels) {
            phase += increment;
            data[i] = (float) (gain * (
                Mathf.Sin((float)(phase * freq * 2.0 * Mathf.PI)) +
                Mathf.Sin((float)(phase * freq * 2.0 * Mathf.PI * spread))
            ));

            if(channels == 2) {
                data[i + 1] = data[i];
            }

            if(phase > (Mathf.PI * 2)) {
                phase = 0.0;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        increment = 1.0 / fs;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
