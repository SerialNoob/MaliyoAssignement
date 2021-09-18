using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSystem : MonoBehaviour
{
    public DifficultyUnit m_gameMode;
    private float m_elapsedTIme = 0.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {
        if (m_gameMode == null)
        {
            return;
        }

        m_elapsedTIme+=Time.deltaTime;
        Debug.Log(m_elapsedTIme);
        if (m_elapsedTIme>=m_gameMode.m_spawnTime)
        {
            Reset();
            GetObject(m_gameMode.GetObstacle());
        }
    }


    void GetObject(GameObject _obj)
    {
        var obj = GameObject.Instantiate(_obj) as GameObject;
        obj.transform.position.Set(obj.transform.position.x, obj.transform.position.y, this.transform.position.z);
    }

    private void Reset()
    {
        m_elapsedTIme=0;
    }
}
