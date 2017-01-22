using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SpalshScreenTransition : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(WaitAndChangeScene());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator WaitAndChangeScene() {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MainMenu");
    }
}
