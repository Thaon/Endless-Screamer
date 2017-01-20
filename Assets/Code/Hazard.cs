using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazard : MonoBehaviour {

    #region member variables

    private float m_speed;

    #endregion

    void Start ()
    {
        m_speed = FindObjectOfType<PersistentData>().m_speed;
	}
	
	void Update ()
    {
        transform.Translate(new Vector3(-1, 0, 0) * m_speed * Time.deltaTime);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
