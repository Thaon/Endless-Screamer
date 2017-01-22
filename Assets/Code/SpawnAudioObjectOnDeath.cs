using UnityEngine;
using System.Collections;

public class SpawnAudioObjectOnDeath : MonoBehaviour {

    public AudioClip m_soundToPlay;

	void OnDestroy ()
    {
        GameObject obj = new GameObject();
        obj.AddComponent<PlaySoundOnDestruction>();
        obj.GetComponent<AudioSource>().clip = m_soundToPlay;
	}
}
