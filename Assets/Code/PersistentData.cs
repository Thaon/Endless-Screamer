using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PersistentData : MonoBehaviour {

    #region member variables

    public float m_actualSpeed = 5;
    public float m_speed = 0;
    public int m_points = 0;

    public bool shielded = false;

    #endregion

    void Awake()
    {
        SceneManager.sceneLoaded += SceneChanged; // subscribe
    }

    void SceneChanged(Scene Scene, LoadSceneMode mode)
    {
        StartCoroutine(UpdateUI());
    }

    void Start ()
    {
        DontDestroyOnLoad(this.gameObject);
	}
	
	public void StartMovement()
    {
        m_speed = m_actualSpeed;
    }

    public void ResetLevel()
    {
        m_speed = 0;
        m_points = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator UpdateUI()
    {
        yield return new WaitForSeconds(.1f);
        GetComponent<InGameUI>().m_screamToStartLabel = GameObject.Find("ScreamText");
        GetComponent<InGameUI>().m_points = GameObject.Find("Points").GetComponent<Text>();
    }

    public void speedup(float extraSpeed) {
        m_speed += extraSpeed;
    }
}
