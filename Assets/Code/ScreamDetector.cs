using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class ScreamDetector : MonoBehaviour
{

    #region member variables

    public float m_sensitivity;
    public GameObject m_startingPosition;

    private AudioSource m_audio;
    private PersistentData m_pData;
    private float[] m_samples;
    private float m_initialHeight;

    #endregion

    void Start()
    {
        m_initialHeight = m_startingPosition.transform.position.y;

        m_pData = FindObjectOfType<PersistentData>();
        m_audio = GetComponent<AudioSource>();

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

        if (m_pData.m_speed > 0)
        {
            transform.position = new Vector3(0, m_initialHeight + vol, 0);
            //Debug.Log("Vol:" + vol); // the actual intensity/ volume of the sound from the microphone	    
        }
        else if (vol > 5)
        {
            m_pData.StartMovement();
        }
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

