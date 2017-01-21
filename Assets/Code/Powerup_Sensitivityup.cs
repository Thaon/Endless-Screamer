using UnityEngine;
using System.Collections;

public class Powerup_Sensitivityup : MonoBehaviour {

    private float m_speed;
    private PersistentData m_pData;
    public float extraSensitivity = 2f;

    // Use this for initialization
    void Start()
    {
        m_pData = FindObjectOfType<PersistentData>();
    }

    // Update is called once per frame
    void Update()
    {
        m_speed = m_pData.m_speed;
        transform.Translate(new Vector3(-1, 0, 0) * m_speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<ScreamDetector>().m_sensitivity += extraSensitivity;

        Destroy(this.gameObject);
    }
}