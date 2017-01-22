using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SpalshScreenTransition : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Find("ScreenFader").GetComponent<ScreenFader>().SetRealAlpha(1);
        GameObject.Find("ScreenFader").GetComponent<ScreenFader>().SetAlpha(0);
        StartCoroutine(WaitAndChangeScene());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator WaitAndChangeScene() {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MainMenu");
    }
}
