using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {

    private bool m_loading = false;

	void Start ()
    {
	    if (!GameObject.Find("PersistentDataGO"))
        {
            GameObject pData = new GameObject("PersistentDataGO");
            pData.AddComponent<PersistentData>();
            pData.AddComponent<InGameUI>();
        }
	}
	
	public void GotoGame()
    {
        if(!m_loading)
        {
            SceneManager.LoadScene("Test");
            m_loading = true;
        }
    }

    public void GotoAndresLevel()
    {
        if (!m_loading)
        {
            GameObject.Find("ScreenFader").GetComponent<ScreenFader>().SetAlpha(1);
            StartCoroutine(GotoGameCO());
        }
    }

    IEnumerator GotoGameCO()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Level 1a");
    }
}
