using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class ScreamThruster : MonoBehaviour
{

    #region member variables

    public float m_sensitivity;

    private AudioSource m_audio;
    private float[] m_samples;
    private float m_initialHeight;
    private Rigidbody m_rb;

    #endregion

    void Start()
    {
        m_initialHeight = transform.position.y;

        m_audio = GetComponent<AudioSource>();
        m_rb = GetComponent<Rigidbody>();

        foreach (string device in Microphone.devices)
        {
            print(device);
        }

        m_audio.clip = Microphone.Start(Microphone.devices[0], true, 180, 44100);

        while (!(Microphone.GetPosition(null) > 0))
        {
        }

        m_audio.Play();

        m_samples = new float[4096]; // 4096 = around 85 ms of samples
    }

    void Update()
    {
        float vol = GetRMS(0) + GetRMS(1);
        vol *= m_sensitivity;

        //transform.position = new Vector3(0, m_initialHeight + vol, 0);
        m_rb.AddForce((Vector3.up * vol) + Vector3.right, ForceMode.Force);
        //Debug.Log("Vol:" + vol); // the actual intensity/ volume of the sound from the microphone	    
    }

    float GetRMS(int channel)
    {
        m_audio.GetOutputData(m_samples, channel); // fill array with samples
        float sum = 0;
        for (var i = 0; i < 4096; i++)
        {
            sum += m_samples[i] * m_samples[i]; // sum squared samples
        }
        return Mathf.Sqrt(sum / 4096); // rms = square root of average 
    }
}

