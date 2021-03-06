﻿using UnityEngine;
using System.Collections;

public class Powerup_FlipVertical : MonoBehaviour {

    #region member variables

    private float m_speed;
    private PersistentData m_pData;

    #endregion

    void Start()
    {
        m_pData = FindObjectOfType<PersistentData>();
    }

    void Update()
    {
        m_speed = m_pData.m_speed;
        transform.Translate(new Vector3(-1, 0, 0) * m_speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            m_pData.targetRotation.z += 180;
            Destroy(this.gameObject);
        }
    }
}