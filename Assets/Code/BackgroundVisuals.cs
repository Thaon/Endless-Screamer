using UnityEngine;
using System.Collections;

public class BackgroundVisuals : MonoBehaviour {

    #region member variables

    public GameObject m_line;
    public GameObject m_linesStartPosition;
    public int m_lines = 250;

    private ScreamDetector m_sd;
    private GameObject[] m_linesGo;
    private LineRenderer[] m_renderers;

    #endregion

    void Start ()
    {
        m_linesGo = new GameObject[m_lines];
        m_renderers = new LineRenderer[m_lines];

        m_sd = FindObjectOfType<ScreamDetector>();

        for (int i = 0; i < m_lines; i++)
        {
            m_linesGo[i] = Instantiate(m_line);
            m_renderers[i] = m_linesGo[i].GetComponent<LineRenderer>();
        }

    }
	
	void Update ()
    {
	    if(m_sd != null)
        {
            for (int i = 0; i < m_lines; i++)
            {
                m_renderers[i].SetPosition(0, new Vector3(m_linesStartPosition.transform.position.x + (i / 10.0f), m_linesStartPosition.transform.position.y, m_linesStartPosition.transform.position.z + 2));
                m_renderers[i].SetPosition(1, new Vector3(m_linesStartPosition.transform.position.x + (i / 10.0f), m_linesStartPosition.transform.position.y + m_sd.m_samples[i] * 20, m_linesStartPosition.transform.position.z + 2));
            }
        }
	}
}
