using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DifficultyUnit", order = 1)]
public class DifficultyUnit : ScriptableObject
{
    public float m_CollectibleCount;
    public GameObject[] m_Obstacles;
    public GameObject[] m_collectible;
    public float m_spawnTime;
    public float m_intermediateSpawnTime;


    public GameObject GetObstacle()
    {
        return m_Obstacles[Random.Range(0, m_Obstacles.Length-1)];
    }

    public GameObject GetCollectible()
    {
        return m_collectible[Random.Range(0, m_collectible.Length-1)];
    }
}

