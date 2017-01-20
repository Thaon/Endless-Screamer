using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour {

    #region member variables

    public GameObject m_screamToStartLabel;
    public Text m_points;

    private PersistentData m_pData;

    #endregion

    void Start ()
    {
        m_pData = FindObjectOfType<PersistentData>();
	}

    void Update()
    {
        if (m_screamToStartLabel != null && m_points != null)
        {

            m_points.text = m_pData.m_points.ToString();
            if (m_pData.m_speed > 0)
            {
                StartGame();
            }
        }
    }

    void StartGame()
    {
        m_screamToStartLabel.SetActive(false);
    }
}
