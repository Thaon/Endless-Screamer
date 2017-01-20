using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazard : MonoBehaviour {

    #region member variables

    public float m_speed;

    #endregion

    void Start () {
	
	}
	
	void Update ()
    {
        transform.Translate(Vector3.left * m_speed * Time.deltaTime);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
