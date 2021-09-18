using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanfoControler : MonoBehaviour
{

    private Vector3[] m_positions;
    private int m_targetPositionIdx = 0;
    private float m_rampTime = 0;
    public float m_deltaFromStart;
    public float m_speed;
    public AnimationCurve m_speedramp;
    public bool m_debug;


    // Start is called before the first frame update
    void Start()
    {
        m_positions=new Vector3[2] { this.transform.position, this.transform.position-new Vector3(m_deltaFromStart, 0, 0) };
    }

    private void OnDrawGizmos()
    {
        if (!m_debug)
        {
            return;
        }
        if (m_positions[0]== null ||m_positions[1]==null)
        {
            return;
        }
        Gizmos.DrawSphere(m_positions[0], .05f);
        Gizmos.DrawSphere(m_positions[1], .05f);

    }

    [ContextMenu("flip")]
    public void FlipTarget()
    {
        m_targetPositionIdx=(m_targetPositionIdx==0) ? 1 : 0;
        m_rampTime=0;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position=Vector3.Lerp(this.transform.position, m_positions[m_targetPositionIdx], Time.deltaTime*(m_speed*m_speedramp.Evaluate(m_rampTime)));
        m_rampTime+=Time.deltaTime;

        m_targetPositionIdx=Convert.ToInt16(Input.GetMouseButton(0));

    }
}
