using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DanfoData", order = 1)]
public class DanfoData : ScriptableObject
{
    public float m_fuelLevel = Globals.MAX_FUEL;
    public int m_lifeCount = 3; 
    public float m_fuelMileage = Globals.Fuel_CONSUMPTIONTIME; // every specified second one unit of fuel is consumed

    public void RemoveFuelPoint()
    {
        if (m_fuelLevel-1>=0)
            m_fuelLevel--;
    }

    public void IncreaseFuelPoint()
    {
        if (m_fuelLevel+1<=Globals.MAX_FUEL)
            m_fuelLevel++;
    }

    public void RemoveLifePoint()
    {
        if (m_lifeCount-1>=0)
            m_lifeCount--;
    }

    
    public void Reset()
    {
        m_fuelLevel=Globals.MAX_FUEL;
        m_lifeCount=3;
        m_fuelMileage=Globals.Fuel_CONSUMPTIONTIME;
    }

    public bool GetGameState()
    {
        return m_lifeCount==0&&m_fuelLevel==0;
    }
}
