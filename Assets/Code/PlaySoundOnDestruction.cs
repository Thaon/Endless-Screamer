using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]

public class PlaySoundOnDestruction : MonoBehaviour {

    private AudioSource m_audio;

    void Start()
    {
        m_audio = GetComponent<AudioSource>();
    }

	IEnumerator PlayAndDie ()
    {
        yield return new WaitForSeconds(m_audio.clip.length);
        Destroy(this.gameObject);
	}
}
