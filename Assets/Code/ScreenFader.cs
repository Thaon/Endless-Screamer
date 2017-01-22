using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFader : MonoBehaviour {

    #region member variables

    private Image m_screenQuad;
    private Color m_color;

    #endregion

    void Awake ()
    {
        m_screenQuad = GetComponent<Image>();
        m_color = m_screenQuad.color;
        m_color.a = 0;
	}
	
	void Update ()
    {
        m_screenQuad.color = Color.Lerp(m_screenQuad.color, m_color, .1f);
	}

    public void SetAlpha(byte alpha)
    {
        m_color.a = alpha;
    }

    public void SetRealAlpha(byte alpha) {
        m_color.a = alpha;
        m_screenQuad.color = m_color;
            
    }
}
