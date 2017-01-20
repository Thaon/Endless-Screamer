using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

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
        SceneManager.LoadScene("Test");
    }

    public void GotoAndresLevel()
    {
        SceneManager.LoadScene("Level 1a");
    }
}
