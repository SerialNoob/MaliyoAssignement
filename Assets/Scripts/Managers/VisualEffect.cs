using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualEffect : MonoBehaviour
{
    public DanfoData m_danfodata;
    private ParticleSystemRenderer m_smokeSys;

    private void Start()
    {
        m_smokeSys = this.GetComponentInChildren<ParticleSystemRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        this.transform.GetChild(0).gameObject.SetActive(m_danfodata.m_lifeCount!=3);

        if (m_danfodata.m_lifeCount < 3)
        {
            m_smokeSys.material.color= (m_danfodata.m_lifeCount==2) ? Color.white : Color.black;
        }
    }
}
