using UnityEngine;
using EZCameraShake;
using System.Collections;

public enum MotionType { precise, physics, talk };

[RequireComponent(typeof(AudioSource))]

public class ScreamDetector : MonoBehaviour
{

    #region member variables

    public float m_sensitivity;
    public GameObject m_startingPosition;
    public MotionType m_type = MotionType.precise;
    public float vol = 0;
    public float m_offset;
    public float[] m_samples;
    public GameObject m_notes;

    private AudioSource m_audio;
    private PersistentData m_pData;
    private Rigidbody m_rb;
    private float m_initialHeight;

    #endregion

    void Start()
    {
        if (m_startingPosition != null)
            m_initialHeight = m_startingPosition.transform.position.y;
        m_rb = GetComponent<Rigidbody>();

        if (m_type == MotionType.precise)
        {
            m_rb.isKinematic = true;
            m_rb.useGravity = false;
        }
        else if (m_type == MotionType.physics)
        {
            m_sensitivity += 30;
        }

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
        Vector3 previousPos = transform.position;
        vol = GetRMS(0) + GetRMS(1);
        vol *= m_sensitivity - m_offset;

        if (m_pData != null)
        {

            Debug.Log("Vol:" + vol); // the actual intensity/ volume of the sound from the microphone

            if (m_pData.m_speed > 0)
            {
                if (m_type == MotionType.precise)
                {
                    Vector3 nextPos = new Vector3(0, m_initialHeight + vol * 2, 0);
                    CameraShaker.Instance.ShakeOnce((vol / m_sensitivity) - 0.4f, 10, 0, 1);
                    transform.position = Vector3.Lerp(previousPos, nextPos, Time.deltaTime * 2);
                }
                else if (m_type == MotionType.physics)
                {
                    m_rb.isKinematic = false;
                    m_rb.useGravity = true;
                    m_rb.AddForce(Vector3.up * vol, ForceMode.Acceleration);
                }

            }
            else if (vol > 5 && m_type != MotionType.talk)
            {
                m_pData.StartMovement();
                m_notes.SetActive(true);
            }
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

