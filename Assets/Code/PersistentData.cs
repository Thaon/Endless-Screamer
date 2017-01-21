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

    private GameObject m_playerExplosion;

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
        m_playerExplosion = Resources.Load("PlayerExplosion") as GameObject;
	}
	
	public void StartMovement()
    {
        m_speed = m_actualSpeed;
        GameObject.Find("Music").GetComponent<AudioSource>().Play();
    }

    public void ResetLevel()
    {
        if (m_speed != 0)
        {
            m_speed = 0;

            GameObject player = GameObject.FindWithTag("Player");
            Instantiate(m_playerExplosion, player.transform.position, Quaternion.identity);
            player.SetActive(false);

            StartCoroutine(ResetLevelCO());
        }
    }

    IEnumerator UpdateUI()
    {
        yield return new WaitForSeconds(.001f);
        GetComponent<InGameUI>().m_screamToStartLabel = GameObject.Find("ScreamText");
        GetComponent<InGameUI>().m_points = GameObject.Find("Points").GetComponent<Text>();
        GetComponent<BackgroundVisuals>().m_linesStartPosition = GameObject.Find("LineStart");
    }

    public void speedup(float extraSpeed) {
        m_speed += extraSpeed;
    }

    IEnumerator ResetLevelCO()
    {
        yield return new WaitForSeconds(1);
        m_points = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
