using UnityEngine;
using System.Collections;

public class PersistentData : MonoBehaviour {

	void Start ()
    {
        DontDestroyOnLoad(this.gameObject);
	}
	
	void Update ()
    {
	
	}
}
