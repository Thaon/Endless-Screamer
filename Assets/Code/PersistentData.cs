using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentData : MonoBehaviour {

    #region member variables

    public float m_actualSpeed = 5;
    public float m_speed = 0;
    public int m_points = 0;

    #endregion

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
