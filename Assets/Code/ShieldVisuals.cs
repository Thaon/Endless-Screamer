using UnityEngine;
using System.Collections;

public class ShieldVisuals : MonoBehaviour {

    public GameObject m_shield;

    private PersistentData m_pData;

    void Start()
    {
        m_pData = FindObjectOfType<PersistentData>();
    }

	void Update ()
    {
        m_shield.SetActive(m_pData.shielded);
	}
}
