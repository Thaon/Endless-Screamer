using UnityEngine;
using System.Collections;

public class MouthSizeController : MonoBehaviour {

    #region member variables

    private ScreamDetector m_sDetector;
    private LineRenderer m_line;

    #endregion

    void Start ()
    {
        m_sDetector = FindObjectOfType<ScreamDetector>();
        m_line = GetComponent<LineRenderer>();
	}
	
	void Update ()
    {
        float volProportional = m_sDetector.vol / m_sDetector.m_sensitivity;
        m_line.SetPosition(0, transform.position + new Vector3(0, -.15f, -2));
        m_line.SetPosition(1, transform.position + new Vector3(0, -.20f - volProportional, -2));
    }
}
