using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DanfoControler : MonoBehaviour
{

    private Vector3[] m_positions;
    private int m_targetPositionIdx = 0;
    private float m_rampTime = 0;
    public float m_deltaFromStart;
    public float m_speed;
    public AnimationCurve m_speedramp;
    public bool m_debug;


    public UnityEvent OnCollection;
    public UnityEvent OnCollision;
    public UnityEvent OnPowerUP;

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


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag.Equals("Obstacle"))
        {
            GameObject.Destroy(collision.gameObject);
            if (OnCollision!=null)
                OnCollision.Invoke();
        }
        else if(collision.gameObject.tag.Equals("Collectible"))
        {
            GameObject.Destroy(collision.gameObject);
            if (OnCollection!=null)
                OnCollection.Invoke();
        }
        else
        {
            GameObject.Destroy(collision.gameObject);
            if (OnPowerUP!=null)
                OnPowerUP.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position=Vector3.Lerp(this.transform.position, m_positions[m_targetPositionIdx], Time.deltaTime*(Globals.SPEED/2)*m_speedramp.Evaluate(m_rampTime));
        m_rampTime+=Time.deltaTime;

        m_targetPositionIdx=Convert.ToInt16(Input.GetMouseButton(0));

    }
}
