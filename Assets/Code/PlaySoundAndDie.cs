using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]

public class PlaySoundAndDie : MonoBehaviour {

    private AudioSource m_audio;

    void Start ()
    {
        m_audio = GetComponent<AudioSource>();
        m_audio.Play();

    }
	
	IEnumerator PlayAndDie ()
    {
        yield return new WaitForSeconds(m_audio.clip.length);
        Destroy(this.gameObject);
	}
}
