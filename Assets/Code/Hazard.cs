using UnityEngine;
using EZCameraShake;

public class Hazard : MonoBehaviour {

    #region member variables

    private float m_speed;
    private PersistentData m_pData;

    #endregion

    void Start ()
    {
        m_pData = FindObjectOfType<PersistentData>();
	}
	
	void Update ()
    {
        m_speed = m_pData.m_speed;
        transform.Translate(new Vector3(-1, 0, 0) * m_speed * Time.deltaTime);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (m_pData.shielded && gameObject.tag != "NonDestructible")
            {
                m_pData.shielded = false;
                CameraShaker.Instance.ShakeOnce(3, 10, 0, 1);
                Destroy(this.gameObject);
            }
            else if (m_pData.shielded && gameObject.tag == "NonDestructible" || !m_pData.shielded)
            {
                m_pData.shielded = false;
                CameraShaker.Instance.ShakeOnce(5, 10, 0, 1);
                m_pData.ResetLevel();
            }
            
        }
    }
}
