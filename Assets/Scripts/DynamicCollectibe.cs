using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCollectibe : MonoBehaviour
{

    private float m_timeElapsed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_timeElapsed+=Time.deltaTime;
        this.transform.position=new Vector3(this.transform.position.x+Mathf.Sin(m_timeElapsed*2)*(Time.deltaTime+.05f), this.transform.position.y, this.transform.position.z);
    }
}
