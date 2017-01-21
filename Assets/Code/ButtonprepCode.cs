using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonprepCode : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
        
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Click() {
        PersistentData pData = FindObjectOfType<PersistentData>();
        pData.ResetLevel();
    }
}
