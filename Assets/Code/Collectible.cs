﻿using UnityEngine;
using System.Collections;
using EZCameraShake;

public class Collectible : MonoBehaviour {

    #region member variables

    private float m_speed;
    private PersistentData m_pData;

    #endregion

    void Start ()
    {
        m_pData = FindObjectOfType<PersistentData>();
    }
	
	void Update ()
    {
        m_speed = m_pData.m_speed;
        transform.Translate(new Vector3(-1, 0, 0) * m_speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CameraShaker.Instance.ShakeOnce(5, 10, 0, 2);
            m_pData.m_points++;
            Destroy(this.gameObject);
        }
    }
}
