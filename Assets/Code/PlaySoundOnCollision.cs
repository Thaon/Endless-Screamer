using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]

public class PlaySoundOnCollision : MonoBehaviour {

    public AudioClip m_soundToPlay;

    private AudioSource m_audio;

    void Start()
    {
        m_audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        m_audio.Play();
        StartCoroutine(PlayAndDie());
    }

    IEnumerator PlayAndDie()
    {
        yield return new WaitForSeconds(m_audio.clip.length);
        Destroy(this.gameObject);
    }

}
