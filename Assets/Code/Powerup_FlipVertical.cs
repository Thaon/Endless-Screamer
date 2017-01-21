using UnityEngine;
using System.Collections;

public class Powerup_FlipVertical : MonoBehaviour {

    #region member variables

    private float m_speed;
    private PersistentData m_pData;
    public Vector3 targetRotation;
    private bool active = true;

    #endregion

    void Start()
    {
        targetRotation = new Vector3(0, 0, 0);
        m_pData = FindObjectOfType<PersistentData>();
    }

    void Update()
    {
        Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, Quaternion.Euler(targetRotation), 0.1f);
        m_speed = m_pData.m_speed;
        transform.Translate(new Vector3(-1, 0, 0) * m_speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && active)
        {
            targetRotation = new Vector3(0, 0, targetRotation.z + 180);
            active = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}