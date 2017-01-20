using UnityEngine;
using System.Collections;

public class PersistentData : MonoBehaviour {

    #region member variables

    public float m_speed = 5;

    #endregion

    void Start ()
    {
        DontDestroyOnLoad(this.gameObject);
	}
	
	void Update ()
    {
	
	}
}
