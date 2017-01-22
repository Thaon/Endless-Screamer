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
    public Vector3 targetRotation;
    private int highScore = 0;

    private GameObject m_playerExplosion;
    private AudioClip m_soundToPlay;

    #endregion

    void Awake()
    {
        SceneManager.sceneLoaded += SceneChanged; // subscribe
    }

    void SceneChanged(Scene Scene, LoadSceneMode mode)
    {
        m_points = 0;
        GetComponent<InGameUI>().m_screamToStartLabel = GameObject.Find("ScreamText");
        GetComponent<InGameUI>().m_points = GameObject.Find("Points").GetComponent<Text>();
        targetRotation = new Vector3(0, 0, 0);
    }

    void Update()
    {
        Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, Quaternion.Euler(targetRotation), 0.1f);
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "MainMenu")
            GotoMainMenu();
        else if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name == "MainMenu")
            Application.Quit();
        UpdateHighScore();
    }

    void Start ()
    {
        DontDestroyOnLoad(this.gameObject);
        m_playerExplosion = Resources.Load("PlayerExplosion") as GameObject;
        m_soundToPlay = Resources.Load("Explosion") as AudioClip;

    }

    void UpdateHighScore() {
        if (m_points > highScore) {
            highScore = m_points;
        }
        if (GameObject.FindGameObjectWithTag("HighScore")!= null) {
            GameObject.FindGameObjectWithTag("HighScore").GetComponent<Text>().text = "High Score: " + highScore.ToString();
        }
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

    public void GotoMainMenu()
    {
        GameObject.Find("ScreenFader").GetComponent<ScreenFader>().SetAlpha(1);
        StartCoroutine(GotoMainMenuCO());
    }

    public void speedup(float extraSpeed) {
        m_speed += extraSpeed;
    }

    IEnumerator ResetLevelCO()
    {
        yield return new WaitForSeconds(1);
        m_points = 0;
        targetRotation = new Vector3(0, 0, 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator GotoMainMenuCO()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("MainMenu");
    }
}
