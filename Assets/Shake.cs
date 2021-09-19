using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    private float m_timer;

    // Update is called once per frame
    void Update()
    {
        this.transform.position+=new Vector3(Mathf.Sin(m_timer*5+2), Mathf.Sin(m_timer*5+0.3f), Mathf.Sin(m_timer*6))*Time.deltaTime;
        m_timer+=Time.deltaTime;
    }
}
