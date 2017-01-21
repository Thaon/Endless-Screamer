using UnityEngine;
using System.Collections;

public class EyeSizeController : MonoBehaviour {

    #region member variables

    private ScreamDetector m_sDetector;

    public bool m_expand = true;

    #endregion

    void Start ()
    {
        m_sDetector = FindObjectOfType<ScreamDetector>();
    }
	
	void Update ()
    {
        float volProportional = m_sDetector.vol / m_sDetector.m_sensitivity;
        if (m_expand)
            transform.localScale = new Vector3(1.1f + volProportional, 1.1f + volProportional, 1.1f + volProportional);
        else
            transform.localScale = new Vector3(.6f - volProportional, .6f - volProportional, .6f - volProportional);
    }
}
