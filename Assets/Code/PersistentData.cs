using UnityEngine;
using System.Collections;

public class PersistentData : MonoBehaviour {

    #region member variables

    public float m_actualSpeed = 5;
    public float m_speed = 0;

    #endregion

    void Start ()
    {
        DontDestroyOnLoad(this.gameObject);
	}
	
	public void StartMovement()
    {
        m_speed = m_actualSpeed;
    }
}
