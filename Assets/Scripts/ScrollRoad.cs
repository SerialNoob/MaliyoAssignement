using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollRoad : MonoBehaviour
{
    Material m_internal;
    Vector2 m_offset;
    public Axis m_direction;
    public int factor;
    public enum Axis
    {
        x,y
    }
    // Start is called before the first frame update
    void Start()
    {
        this.m_internal=this.gameObject.GetComponent<Renderer>().material;
        m_offset=m_internal.GetTextureOffset(m_internal.GetTexturePropertyNames()[0]);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_direction == Axis.x)
        {
            m_offset=new Vector2(m_offset.x+Globals.SPEED/factor*Time.deltaTime, m_offset.y);

        }
        else
        {
            m_offset=new Vector2(m_offset.x, m_offset.y+Globals.SPEED/factor*Time.deltaTime);

        }


        m_internal.SetTextureOffset(m_internal.GetTexturePropertyNames()[0], m_offset);
    }
}
