using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSystem : MonoBehaviour
{
    private const int FACTOR = 10;
    public DifficultyUnit m_gameMode;
    private float m_elapsedTIme = 0.0f;
    private float m_elapsedTImeNonReset = 0.0f;
    private bool m_generatedCollectibles = false;
    private DifficultyManager m_difficultyManager;

    // Start is called before the first frame update
    void Start()
    {
        m_difficultyManager=this.GetComponent<DifficultyManager>();
    }

    

    // Update is called once per frame
    void Update()
    {

        if (m_gameMode == null)
        {
            return;
        }

        m_elapsedTIme+=Time.deltaTime;

        m_elapsedTImeNonReset+=Time.deltaTime;

        if (m_generatedCollectibles==false && m_elapsedTIme<=m_gameMode.m_intermediateSpawnTime)
        {
            if(UnityEngine.Random.Range(0,10) > 5)
            {
                GetObject(m_gameMode.GetCollectible());
                m_generatedCollectibles=true;
            }
        }

        if (m_elapsedTIme>=m_gameMode.m_spawnTime)
        {
            Reset();
            Upgrade();
            GetObject(m_gameMode.GetObstacle());
        }
    }

    private void Upgrade()
    {
        m_gameMode=m_difficultyManager.GetProperDifficultyUnit(m_elapsedTImeNonReset/FACTOR);
    }

    void GetObject(GameObject _obj)
    {
        var obj = GameObject.Instantiate(_obj) as GameObject;
        if(obj.tag.Equals("Colectible"))
            obj.GetComponent<CollectibleReducer>().Reduce((int)m_gameMode.m_CollectibleCount);
        obj.transform.position.Set(obj.transform.position.x, obj.transform.position.y, this.transform.position.z);
    }

    private void Reset()
    {
        m_elapsedTIme=0;
        m_generatedCollectibles=false;
    }
}
