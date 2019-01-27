using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    private float freq = 220.0f;
    public float spread = 0.75f;
    public float gain = 0.25f;

    public float f1 = 2.0f;
    public float f2 = 0.666f;

    public float seq_freq = 2.0f;

    private float phase_sq;
    private float phase_saw;
    private float phase_seq;

    private float fs = 48000.0f;

    private float[] seq = new float[] {196.0f, 293.66f, 440.0f};

    private float[] sub_seq = new float[] {1.0f, 5.0f/6.0f, 3.0f/4.0f};

    private int seq_idx;
    private float seq_count = 0.0f;

    float square(float phase) {
        return phase < Mathf.PI ? -1.0f : 1.0f;
    }

    float saw(float phase) {
        return -1.0f + phase / Mathf.PI;
    }

    void OnAudioFilterRead(float[] data, int channels) {
        

        for(int i = 0; i < data.Length; i += channels) {

            seq_idx = (int)(phase_seq * 3.0f);
            freq = seq[seq_idx < 3 ? seq_idx : 2] * sub_seq[(int)seq_count % 3];

            phase_sq += freq * 2.0f * Mathf.PI * f1 / fs;
            phase_saw += freq * 2.0f * Mathf.PI * f2 / fs;
            phase_seq += seq_freq * 1.5f / fs;

            data[i] = gain * (
                0.5f * square(phase_sq) +
                0.5f * saw(phase_saw)
            );

            if(channels == 2) {
                data[i + 1] = data[i];
            }

            if(phase_sq > (Mathf.PI * 2)) {
                phase_sq = 0.0f;
            }
            if(phase_saw > (Mathf.PI * 2)) {
                phase_saw = 0.0f;
            }

            if(phase_seq > 1.0f) {
                phase_seq = 0.0f;
                seq_count += 1.0f / 11.0f;
            }
        }
    }

    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update()
    {
        
    }
}
