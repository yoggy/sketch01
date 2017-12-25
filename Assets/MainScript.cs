using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour {

    [SerializeField]
    AudioSource audio_source;
    float[] spectrum = new float[1024];

    [SerializeField]
    RectTransform rect_transform;

    void Start () {
		
	}
	
	void Update () {
        audio_source.GetSpectrumData(spectrum, 0, FFTWindow.Hamming);

        float p = 0.0f;
        float delta = AudioSettings.outputSampleRate / spectrum.Length;

        for (int i = 0; i < spectrum.Length - 1; ++i)
        {
            var freq = delta * i;
            if (freq <= 60000)
            {
                p += spectrum[i]; // 30k～60Hz
            }

            rect_transform.transform.localScale = new Vector3(p * 1, p * 1, p * 1);
        }



        Debug.Log(p);
    }
}
