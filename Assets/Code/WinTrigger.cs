using UnityEngine;
using System.Collections;

public class WinTrigger : MonoBehaviour {

    private PersistentData m_pData;
    private float m_speed;
    public GameObject VictoryLabel;
    public GameObject screamAgain;
    private GameObject player;


    // Use this for initialization
    void Start () {
        m_pData = FindObjectOfType<PersistentData>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        m_speed = m_pData.m_speed;
        transform.Translate(new Vector3(-1, 0, 0) * m_speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            //game end
            screamAgain.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //game end
            Debug.Log("you win!!!");
            VictoryLabel.SetActive(true);
            screamAgain.SetActive(false);
            player.GetComponent<ScreamDetector>().enabled = false;
            m_pData.m_points *= Mathf.RoundToInt(player.transform.position.y);
            m_pData.m_speed = 0;
            m_pData.GotoMainMenu();
        }
    }
}
