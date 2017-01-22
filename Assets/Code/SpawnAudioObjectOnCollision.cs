using UnityEngine;
using System.Collections;

public class SpawnAudioObjectOnCollision : MonoBehaviour {

    public GameObject m_audioObject;

    void OnTriggerEnter(Collider other)
    {
        Instantiate(m_audioObject);
    }
}
