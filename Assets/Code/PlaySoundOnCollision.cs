using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]

public class PlaySoundOnCollision : MonoBehaviour {

    private AudioSource m_audio;

    void Start()
    {
        m_audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        m_audio.Play();
    }
}
